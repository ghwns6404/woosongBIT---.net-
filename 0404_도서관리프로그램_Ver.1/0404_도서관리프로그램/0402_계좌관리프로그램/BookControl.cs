//AccountControl.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Xml.Linq;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0404_도서관리프로그램
{
    internal class BookControl
    {
        MyDB myDB = MyDB.Singleton; 

        #region 0. 싱글톤 패턴
        public static BookControl Singleton { get; } = null;
        static BookControl()
        {
            Singleton = new BookControl();
        }  
        #endregion


        #region 1. 기능 메서드
        public void BookInsert() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 저장]\n");

                string name = WbLib.InputString("도서명 입력");
                int price = WbLib.InputInteger("가격 입력");
                string description = WbLib.InputString("저자 입력");

                string sql = string.Format($"INSERT INTO s_product VALUES('{name}', {price}, '{description}')");
                MyDB.Singleton.ExSqlCommand(sql);

                Console.WriteLine("도서 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서 저장 실패] " + ex.Message);
            }
        }
        public void BookSelect()//ㅇㅋ
        {
            try
            {

                Console.WriteLine("\n[도서 검색]\n");

                string name = WbLib.InputString("도서명 입력");

                Book b1 = myDB.SelectBook(name);

                Console.WriteLine("-------------------------------");
                Console.WriteLine("책번호 : " +b1.Number);
                Console.WriteLine("도서명 : " + b1.Name);
                Console.WriteLine("가 격 : " +  b1.Price);
                Console.WriteLine("저 자 : " +  b1.Description);
                Console.WriteLine("-------------------------------");

                Console.WriteLine("[도서 검색 성공] ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서 검색 실패] " + ex.Message);
            }
        }
        public void BookUpdate() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 수정]\n");

                string name = WbLib.InputString("도서명 입력");
                int price = WbLib.InputInteger("수정금액 입력");

                string sql = string.Format($"update s_product set price = {price} where pname = '{name}';");
                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정 실패] " + ex.Message);
            }
        }
        public void BookDelete() //ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 삭제]\n");

                string name = WbLib.InputString("삭제할 도서명 입력");
                string sql = string.Format($"delete from s_product where pname='{name}';");
                MyDB.Singleton.ExSqlCommand(sql);


                Console.WriteLine("도서 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }
        public void SelectNameAll()//ㅇㅋ
        {
            try
            {
                Console.WriteLine("\n[도서 전체출력]\n");

                List<Book> books = new List<Book>();
                string sql = string.Format($"select * from s_Product;");

                List<Book> printall =  myDB.SelectAll();

                foreach(Book book in printall)
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("책번호 : " + book.Number);
                    Console.WriteLine("도서명 : " + book.Name);
                    Console.WriteLine("가  격 : " + book.Price);
                    Console.WriteLine("저  자 : " + book.Description);
                    Console.WriteLine("-------------------------------------------------");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("[전체출력 실패] " + ex.Message);
            }
        }
        #endregion

        //#region 2. 내부에서 사용되는 메서드
        //private int TitlerToIdx(string title)
        //{
        //    for (int i = 0; i < books.Size; i++)
        //    {
        //        Book book = books.Book_Change(i);
        //        if (book.Title == title)
        //            return i;
        //    }
        //    throw new Exception("없는 도서 입니다.");
        //}
        //private Book TitleToAccount(string title)
        //{
        //    for (int i = 0; i < books.Size; i++)
        //    {
        //        Book book = books.Book_Change(i);
        //        if (book.Title == title)
        //            return book;
        //    }
        //    throw new Exception("없는 도서 입니다.");
        //}
        //#endregion

        public void Init()
        {
            try
            {
                if (myDB.Connect() == false)
                    return;
                Console.WriteLine("---DB연결됨---");
            }
            catch(Exception ex)
            {
                Console.WriteLine("[DB연결 실패] " + ex.Message);
            }
            WbLib.Pause(); 
        }

        public void Exit()
        {
            if (myDB.Close() == true)
                Console.WriteLine("DB연결종료");
        }
    }
}