//AccountControl.cs
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using WoosongBit41.Data;
using WoosongBit41.File;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class AccountControl
    {
        private List<Account> accounts = new List<Account>();      //계좌리스트 저장
        public List<Account> Accounts    { get { return accounts; } }
        public int Accounts_Count        {  get { return accounts.Count; } }    

        
        private List<AccountIO> accountios = new List<AccountIO>();//거래 내역 저장
        public List<AccountIO> Accountios { get { return accountios; } }

        private LogManager logmanager = null;

        #region 이벤트 
        public event LogDel InsertAccount   = null;
        public event LogDel SelectAccount   = null;
        public event LogDel InputAccount    = null;
        public event LogDel OutputAccount   = null;
        public event LogDel DeleteAccount   = null;

        public event LogDel TotalAccount    = null;
        #endregion 

        #region 0. 싱글톤 패턴
        public static AccountControl Singleton { get; } = null;
        static AccountControl() { Singleton = new AccountControl(); }
        private AccountControl() 
        {
        }
        #endregion

        #region 1. 임시 데이터 입력
        private void Temp()
        {
            accounts.Add(new Account(1000, "홍길동", 1000));
            accountios.Add(new AccountIO(1000, 1000, 0, 1000));

            accounts.Add(new Account(1010, "김길동", 2000));
            accountios.Add(new AccountIO(1010, 2000, 0, 2000));

            accounts.Add(new Account(1020, "고길동", 3000));
            accountios.Add(new AccountIO(1020, 3000, 0, 3000));
        }
        #endregion

        #region 2. 기능 메서드
        public void AccountInsert(int number, string name, int money)
        {
            try
            {
                //number 중복 처리
                Account temp = accounts.Find(acc => acc.Number == number);
                if (temp != null)
                    throw new Exception("중복된 번호 입니다");

                //계좌 저장
                Account account = new Account(number, name, money);
                accounts.Add(account);

                //거래 내역 저장
                AccountIO accountio = new AccountIO(number, money, 0, money);
                accountios.Add(accountio);
            }
            catch (Exception ex)
            {
                throw ex;   //예외 재 전송!!!!
            }

            //이벤트 발생(게시)
            if (InsertAccount != null)
            {
                InsertAccount(this, new LogArgs(LogType.Input_Account, "계좌 개설"));
                TotalAccount(this, new LogArgs(LogType.Input_Account, "계좌 개설"));
            }
        }
        public Account NumberToAccount(int number)
        {
            Account account = accounts.Find(acc => acc.Number == number);
            if (account != null)
            {
                //이벤트 발생(게시)
                if (SelectAccount != null)
                {
                    SelectAccount(this, new LogArgs(LogType.Select_Account, "계좌 검색"));
                    TotalAccount(this, new LogArgs(LogType.Select_Account, "계좌 검색"));
                }
                return account;
            }
            else
                throw new Exception("없는 계좌번호 입니다.");

            
        }
        public List<AccountIO> AccountIOPrint(int number)
        {
            List<AccountIO> temp =  accountios.FindAll(acc => acc.Number == number);
            return temp;
        }
        public void AccountDelete(int number)
        {
            try
            {
                Account account = accounts.Find(acc => acc.Number == number);
                if (account == null)
                    throw new Exception("없는 계좌번호 입니다.");

                accounts.Remove(account);
                AccountIODeleteAll(number);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //이벤트 발생(게시)
            if (DeleteAccount != null)
            {
                DeleteAccount(this, new LogArgs(LogType.Delete_Account, "계좌 삭제"));
                TotalAccount(this, new LogArgs(LogType.Delete_Account, "계좌 검색"));
            }
        }
        public void AccountInput(int number, int money)
        {
            try
            {
                Account account = NumberToAccount(number);
                account.Input_Money(money);

                AccountIO accountio = new AccountIO(number, money, 0, account.Balance);
                accountios.Add(accountio);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //이벤트 발생(게시)
            if (InputAccount != null)
            {
                InputAccount(this, new LogArgs(LogType.Input_Account, "계좌 입금"));
                TotalAccount(this, new LogArgs(LogType.Input_Account, "계좌 입금"));
            }
        }
        public void AccountOutput(int number, int money)
        {
            try
            {
                Account account = NumberToAccount(number);
                account.Output_Money(money);

                AccountIO accountio = new AccountIO(number, 0, money, account.Balance);
                accountios.Add(accountio);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //이벤트 발생(게시)
            if (OutputAccount != null)
            {
                OutputAccount(this, new LogArgs(LogType.Output_Account, "계좌 출금"));
                TotalAccount(this, new LogArgs(LogType.Output_Account, "계좌 출금"));
            }
        }
        public List<Account> SelectAllName(string name)
        {
            List<Account> temp = accounts.FindAll(acc => acc.Name == name);
            return temp;
        }
        #endregion

        #region 3. 내부에서 사용되는 메서드            
        private void AccountIODeleteAll(int number)
        {
            for (int i = accountios.Count-1; i >= 0 ; i--)
            {
                AccountIO accountio = (AccountIO)accountios[i];
                if (accountio.Number == number)
                {
                    accountios.RemoveAt(i);
                }
            }
        }
        #endregion

        #region 4. 시작과 종료 메서드
        public void Init()
        {
            try
            {
                logmanager = new LogManager();          //** 생성자에서 만들지 못하는 이유!!!

                WbFile.Read_Accounts(accounts);
                WbFile.Read_Accountios(accountios);
                Console.WriteLine("파일 로드 성공.................");
            }
            catch (Exception ex)
            {
                Console.WriteLine("파일 로드 실패(최초 실행)..........");
                Console.WriteLine(ex.Message);
            }
            WbLib.Pause();
        }
        public void Exit()
        {
            WbFile.Write_Accounts(accounts);
            WbFile.Write_Accountios(accountios);

            logmanager.Dispose();   //******************
        }
        #endregion
    }
}