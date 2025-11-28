//AccountControl.cs
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class AccountControl
    {
        MyMemoryDB db = new MyMemoryDB();
        
        #region 0. 싱글톤 패턴
        public static AccountControl Singleton { get; } = null;
        static AccountControl() { Singleton = new AccountControl(); }
        private AccountControl() 
        {
            //accountios = new WbArray(100);
            //Temp();
        }
        #endregion
        
        #region 1. 임시 데이터 입력
        //private void Temp()
        //{
        //    accounts.Add(new Account(1000, "홍길동", 1000));
        //    accountios.Add(new AccountIO(1000, 1000, 0, 1000));

        //    accounts.Add(new Account(1010, "김길동", 2000));
        //    accountios.Add(new AccountIO(1010, 2000, 0, 2000));

        //    accounts.Add(new Account(1020, "고길동", 3000));
        //    accountios.Add(new AccountIO(1020, 3000, 0, 3000));
        //}
        #endregion
        
        #region 2. 기능 메서드
        public void AccountInsert()//삽입
        {
            try
            { 
                Console.WriteLine("\n[계좌 저장]");
                Console.WriteLine("###계좌번호는 자동등록됩니다###]");

                string name = WbLib.InputString("이름 입력");
                int balance = WbLib.InputInteger("입금액 입력");
                DateTime date = DateTime.Now;

                int id = db.Account_Insert(name, balance);

                db.AccountIO_Insert(balance, 0, balance);

                Console.WriteLine("저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[계좌 개설] " + ex.Message);
            }
        }
        public void AccountDelete() //삭제
        {
            try
            {
                Console.WriteLine("\n[계좌 삭제]\n");

                int number = WbLib.InputInteger("계좌번호 입력");

                db.Account_Delete(number);

                Console.WriteLine("계좌 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }
        public void AccountInput()//수정 - 입금
        {
            try
            {
                Console.WriteLine("\n[계좌 입금]\n");

                int number = WbLib.InputInteger("계좌번호 입력");
                int balance = WbLib.InputInteger("입금액 입력");

                db.Account_Update_InputMoney(number, balance);
                db.AccountIO_Insert(balance, 0, balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[입금 실패] " + ex.Message);
            }
        }
        public void AccountOutput()//수정 - 출금
        {
            try
            {
                Console.WriteLine("\n[계좌 출금]\n");

                int number = WbLib.InputInteger("계좌번호 입력");
                int balance = WbLib.InputInteger("출금액 입력");

                db.Account_Update_OutputMoney(number, balance);
                db.AccountIO_Insert(0, balance, balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[출금 실패] " + ex.Message);
            }
        }
        public void SelectNumber()//검색 - 계좌번호로
        {
            try
            {
                Console.WriteLine("\n[계좌 검색]\n");

                int number = WbLib.InputInteger("계좌번호 입력");
                db.Account_Select(number);

                Account account = db.Account_Select(number);
                account.Println();  

            }
            catch (Exception ex)
            {
                Console.WriteLine("[계좌 검색 실패] " + ex.Message);
            }
        }
        public void AccountPrintAll()
        {
            List<Account> accounts = db.Account_SelectAll();
            foreach(Account account in accounts)
            {
                account.Print();
            }   
        }
        public void AccountIOPrintAll()
        {
           
        }
        #endregion

        #region 2. 시작과 종료 메서드
        public void Init()
        {
            try
            {
                db.Account_Read_Xml();

                db.AccountIO_Read_Xml();   
                db.Create_accountio_table();


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
           db.Account_Write_Xml();
           db.AccountIO_Write_Xml();
           //WbFile.Write_Accountios(accountios);
        }
        #endregion
    }
}