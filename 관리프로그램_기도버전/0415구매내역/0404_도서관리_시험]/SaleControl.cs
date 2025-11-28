using System;
using WoosongBit41.Data;
using WoosongBit41.Lib;
using WoosongBit41.DB;
using System.Collections.Generic;

namespace _0404_도서관리_시험_
{
    internal class SaleControl
    {
        private MyDB myDB = new MyDB();

        #region 0. 싱글톤 패턴
        public static SaleControl Singleton { get; } = null;
        static SaleControl() { Singleton = new SaleControl(); }
        #endregion

        #region 1. 기능 메서드
        public void SaleInsert()
        {
            try
            {
                Console.WriteLine("\n[구매내역 저장]\n");

                string cname = WbLib.InputString("살 사람 입력");
                string pname = WbLib.InputString("책 이름 입력");
                int count = WbLib.InputInteger("몇개살지 입력");


                if (myDB.Insert_Sale(cname, pname, count) == false)
                {
                    throw new Exception("저장 실패");
                }

                Console.WriteLine("도서내역 저장 성공");

            }
            catch (Exception ex)
            {
                Console.WriteLine("[Insert 실패] " + ex.Message);
            }
        }
        public void SelectSale()
        {
            try
            {
                Console.WriteLine("\n[거래내역 검색]\n");

                int Sid = WbLib.InputInteger("SID 입력");

                Sale sale = myDB.SelectSale(Sid);
                if (sale == null)
                {
                    throw new Exception("검색 실패");
                }
                sale.Println();
                Book books = myDB.SelectBook(sale.Pid);
                Member members = myDB.SelectMember(sale.Cid);

            }
            catch (Exception ex)
            {
                Console.WriteLine("[검색 실패] " + ex.Message);
            }
        }
        public void SaleUpdate()
        {
            try
            {
                Console.WriteLine("//책의 갯수만 바뀝니다");
                string mname = WbLib.InputString("수정할 멤버의 이름을 입력(멤버이름 선택)");
                string bname = WbLib.InputString("수정할 도서의 이름을 입력(책 이름 선택)");
                int count = WbLib.InputInteger("수정할 개수 입력(얘만 바뀜)");

                myDB.Update_Sale(mname, bname, count);

                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void SaleDelete()
        {
            try
            {
                Console.WriteLine("\n[구매내역 삭제]\n");

                string cname = WbLib.InputString("구매자 이름 입력");
                string pname = WbLib.InputString("책 이름 입력");

                if (myDB.Delete_Book(cname, pname) == false)
                {
                    throw new Exception("예외");
                }

                Console.WriteLine("구매내역 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[구매내역 삭제 실패] " + ex.Message);
            }
        }

        public void SalePrintAll()//처음 콘솔에 출력
        {
            List<Sale> books = myDB.SelectAllSale();
            // 받은 sid -> 조인 pname, cname 
            Console.WriteLine("저장개수 : {0}개", books.Count);
            Console.WriteLine("-------------------------[거래내역]------------------------- ");
            foreach (Sale sale in books)
            {
                string pname = string.Empty;
                string cname = string.Empty;
                myDB.SelectNameSale(sale.Sid, out pname, out cname);
                Console.Write("SID :" + sale.Sid + "\t\t");
                Console.Write("CID:" + sale.Cid + "\t\t");
                Console.WriteLine("PID:" + sale.Pid + "\t\t");
                Console.Write("구매자:" + cname +"\t\t");
                Console.Write("책이름:" + pname+ "\t\t");
                Console.WriteLine("구매 개수:" + sale.Count);
                Console.WriteLine("구매한 날짜:" + sale.Date);
                Console.WriteLine("------------------------------------------------------------");
            }
        }
        public void BookPrintAll()//처음 콘솔에 출력
        {
            List<Book> books = myDB.SelectAllBook();
            Console.WriteLine("[책 Table] 저장개수 : {0}개", books.Count);
            for (int i = 0; i < books.Count; i++)
            {
                Book book = books[i];
                book.Print();
            }
        }
        public void MemberPrintAll()//처음 콘솔에 출력
        {
            List<Member> books = myDB.SelectAllMember();
            Console.WriteLine("\n[고객 Table]저장개수 : {0}개", books.Count);
            for (int i = 0; i < books.Count; i++)
            {
                Member book = books[i];
                book.Print();
            }
        }
        #endregion

        #region 2. 시작과 종료 메서드
        public void Init()
        {
            if (myDB.Connect() == false)
                return;
            Console.WriteLine("DB연결");

            WbLib.Pause();
        }
        public void Exit()
        {
            myDB.Close();
        }
        #endregion
    }
}


