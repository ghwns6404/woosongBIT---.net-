//BookControl.cs
using System;
using WoosongBit41.Data;
using WoosongBit41.File;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class BookControl
    {
        private BookArray books = new BookArray();         //책 저장
     

        #region 0. 싱글톤 패턴s
        public static BookControl Singleton { get; } = null;
        static BookControl() { Singleton = new BookControl(); }
        private BookControl() 
        {
            //bookios = new BookArray();
            //Temp();
        }
        #endregion

        #region 1. 기능
        public void InsertBook()    //책 저장
        {
            try
            {
                Console.WriteLine("\n도서 저장\n");

                string title = WbLib.InputString("책 입력");
                int price = WbLib.InputInteger("가격 입력");
                string author = WbLib.InputString("저자 입력");

                //도서 저장
                Book account = new Book(title, price, author);
                books.Add(account);

                Console.WriteLine("도서 저장 성공");
                Console.WriteLine("도서 내역 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서생성] " + ex.Message);
            }
        }
        public void SelectBook()
        {
            try
            {
                Console.WriteLine("\n[도서명 검색]\n");

                string title = WbLib.InputString("도서명 입력");

                Book book = TitleToBook(title);

                book.Println();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[도서명 검색 실패] " + ex.Message);
            }
        }   //책 검색
        public void UpdateBook()    //책 수정  //수정
        {
            try
            {
                Console.WriteLine("\n[도서수정 ]\n");

                string title = WbLib.InputString("도서명 입력");
                int price = WbLib.InputInteger("가격 입력");

                int idx = TitleToIdx(title);
                Book book = books[idx];

                book.Price = price;

                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[수정 실패] " + ex.Message);
            }
        }
        public void DeleteBook()
        {
            try
            {
                Console.WriteLine("\n도서 삭제]\n");

                string title = WbLib.InputString("n도서 입력");

                int idx = TitleToIdx(title);

                books.RemoveIdx(idx);

                Console.WriteLine("도서 삭제 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[삭제 실패] " + ex.Message);
            }
        }   //책 삭제
        public void SortBook()
        {
            books.get_Books().Sort();
            Console.WriteLine("title 오름차순 정렬 성공");
        }   
        public void BookPrintAll()
        {
            //Console.WriteLine("저장개수 : {0}개", books.Size);
            for (int i = 0; i < books.Size; i++)
            {
                Book book = books[i];
                book.Print();
            }
        }
        #endregion

        #region 3. 내부에서 사용되는 메서드
        private int TitleToIdx(string title)
        {
            for (int i = 0; i < books.Size; i++)
            {
                Book book = (Book)books[i];
                if (book.Title == title)
                    return i;
            }
            throw new Exception("없는 책 입니다.");
        }
        private Book TitleToBook(string title)
        {
            for (int i = 0; i < books.Size; i++)
            {
                Book book = (Book)books[i];
                if (book.Title == title)
                    return book;
            }
            throw new Exception("없는 책 입니다.");
        }
        #endregion

        #region 4. 시작과 종료 메서드
        public void Init()
        {
            try
            {
                WbFile.Read_Books(books);
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
            WbFile.Write_books(books);
        }
        #endregion
    }
}