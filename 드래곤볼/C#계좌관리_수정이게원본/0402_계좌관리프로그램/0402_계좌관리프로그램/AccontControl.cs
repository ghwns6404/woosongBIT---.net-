//AccountControl.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Data;
using WoosongBit41.File;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class AccountControl
    {
        private WbArray accounts = new WbArray();   //계좌리스트 저장
        private WbArray accountios;                               //거래 내역 저장

        #region 0. 싱글톤 패턴
        public static AccountControl Singleton { get; } = null;
        static AccountControl() { Singleton = new AccountControl(); }
        private AccountControl() 
        {
            accountios = new WbArray();
            //Temp();
        }
        #endregion

        #region 1. 임시 데이터 입력
        private void Temp()
        {
            accounts.Add(new Account(500, "정길동", 5000));
            accountios.Add(new AccountIO(500, 5000, 0, 5000));

            accounts.Add(new Account(100, "김길동", 1000));
            accountios.Add(new AccountIO(100, 1000, 0, 1000));

            accounts.Add(new Account(400, "최길동", 4000));
            accountios.Add(new AccountIO(400, 4000, 0, 4000));
            accounts.Add(new Account(500, "정길동", 5000));
            accountios.Add(new AccountIO(500, 5000, 0, 5000));

            accounts.Add(new Account(100, "김길동", 1000));
            accountios.Add(new AccountIO(100, 1000, 0, 1000));

            accounts.Add(new Account(400, "최길동", 4000));
            accountios.Add(new AccountIO(400, 4000, 0, 4000));
        }
        #endregion

        #region 2. 기능 메서드
        public void AccountInsert()
        {
            try
            {
                Console.WriteLine("\n[계좌 저장]\n");

                int number = WbLib.InputInteger("계좌번호 입력");
                string name = WbLib.InputString("이름 입력");
                int balance = WbLib.InputInteger("입금액 입력");

                //계좌 저장
                Account account = new Account(number, name, balance);
                accounts.Add(account);

                //거래 내역 저장
                AccountIO accountio = new AccountIO(number, balance, 0, balance);
                accountios.Add(accountio);

                Console.WriteLine("계좌 저장 성공");
                Console.WriteLine("거래 내역 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[계좌 개설] " + ex.Message);
            }
        }
        public void AccountIOPrintAll()
        {
            Console.WriteLine("저장개수 : {0}개", accountios.Arr.Count);
            for (int i = 0; i < accountios.Arr.Count; i++)
            {
                AccountIO accountio = (AccountIO)accountios[i];
                accountio.Print();
            }
        }
        public void AccountPrintAll()
        {
            Console.WriteLine("저장개수 : {0}개", accounts.Arr.Count);
            for (int i = 0; i < accounts.Arr.Count; i++)
            {
                Account account = (Account)accounts[i];
                account.Print();
            }
        }
        public void SelectNumber()
        {
            try
            {
                Console.WriteLine("\n[계좌 검색]\n");

                int number = WbLib.InputInteger("계좌번호 입력");

                Account account = NumberToAccount(number);

                account.Println();
                Console.WriteLine("--------------------------------------------");
                AccountIOPrint(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[계좌 검색 실패] " + ex.Message);
            }
        }
        public void AccountInput()
        {
            try
            {
                Console.WriteLine("\n[계좌 입금]\n");

                int number = WbLib.InputInteger("계좌번호 입력");
                int money = WbLib.InputInteger("입금액 입력");

                Account account = NumberToAccount(number);
                account.Input_Money(money);

                AccountIO accountio = new AccountIO(number, money, 0, account.Balance);
                accountios.Add(accountio);

                Console.WriteLine("입금 성공");
                Console.WriteLine("거래내역 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[입금 실패] " + ex.Message);
            }
        }
        public void AccountOutput()
        {
            try
            {
                Console.WriteLine("\n[계좌 출금]\n");

                int number = WbLib.InputInteger("계좌번호 입력");
                int money = WbLib.InputInteger("출금액 입력");

                Account account = NumberToAccount(number);
                account.Output_Money(money);

                AccountIO accountio = new AccountIO(number, 0, money, account.Balance);
                accountios.Add(accountio);

                Console.WriteLine("출금 성공");
                Console.WriteLine("거래내역 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[출금 실패] " + ex.Message);
            }
        }
        public void AccountDelete()
        {
            try
            {
                Console.WriteLine("\n[계좌 삭제]\n");

                int number = WbLib.InputInteger("계좌번호 입력");

                int idx = NumberToIdx(number);

                accounts.RemoveIdx(idx);
                AccountIODeleteAll(number);

                Console.WriteLine("계좌 삭제 성공");
                Console.WriteLine("거래내역 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }
        public void SelectNameAll()
        {
            try
            {
                Console.WriteLine("\n[계좌 검색(이름)]\n");

                string name = WbLib.InputString("이름 입력");

                for (int i = 0; i < accounts.Arr.Count; i++)
                {
                    Account account = (Account)accounts[i];
                    if (account.Name == name)
                        account.Print();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[검색 실패] " + ex.Message);
            }
        }

        //계좌번호를 오름차순으로 정렬
        public void AccountSort()
        {
            accounts.Arr.Sort((a, b) => ((Account)a).Balance.CompareTo(((Account)b).Balance));
            Console.WriteLine("계좌번호 오름차순 정렬 성공");
        }
        #endregion

        #region 3. 내부에서 사용되는 메서드
        private int NumberToIdx(int number)
        {
            for (int i = 0; i < accounts.Arr.Count; i++)
            {
                Account account = (Account)accounts[i];
                if (account.Number == number)
                    return i;
            }
            throw new Exception("없는 계좌번호 입니다.");
        }
        private Account NumberToAccount(int number)
        {
            for (int i = 0; i < accounts.Arr.Count; i++)
            {
                Account account = (Account)accounts[i];
                if (account.Number == number)
                    return account;
            }
            throw new Exception("없는 계좌번호 입니다.");
        }
        private void AccountIOPrint(int number)
        {
            for (int i = 0; i < accountios.Arr.Count; i++)
            {
                AccountIO accountio = (AccountIO)accountios[i];
                if (accountio.Number == number)
                    accountio.Print();
            }
        }
        private void AccountIODeleteAll(int number)
        {
            for (int i = accountios.Arr.Count -1; i >= 0 ; i--)
            {
                AccountIO accountio = (AccountIO)accountios[i];
                if (accountio.Number == number)
                {
                    accountios.RemoveIdx(i);
                }
            }
        }
  
        #endregion

        #region 4. 시작과 종료 메서드
        public void Init()
        {
            try
            {
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
        }
        #endregion
    }
}