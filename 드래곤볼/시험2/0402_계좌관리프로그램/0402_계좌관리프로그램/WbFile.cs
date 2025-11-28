//WbFile.cs
using System;
using WoosongBit41.Lib;
using WoosongBit41.Data;
using System.IO;
using System.Diagnostics;

namespace WoosongBit41.File
{
    internal static class WbFile
    {
        private const string BOOKS_FILENAME = "books.txt";

        //text모드(데이터 기반)
        public static void Write_books(BookArray books)
        {
            StreamWriter writer = new StreamWriter(BOOKS_FILENAME);
            writer.WriteLine(books.Size);
            for (int i = 0; i < books.Size; i++)
            {
                Book book = books[i];
                string temp = string.Empty;
                temp += book.Title + "@";
                temp += book.Price + "@";
                temp += book.Author;
                writer.WriteLine(temp);
            }
            writer.Dispose();
        }       
        public static void Read_Books(BookArray books)
        {
            StreamReader reader = new StreamReader(BOOKS_FILENAME);
            int size = int.Parse(reader.ReadLine());
            for (int i = 0; i < size; i++)
            {
                string temp = reader.ReadLine();  //도서명@가격@저자
                string[] sp = temp.Split('@');
                string title = sp[0];
                int price = int.Parse(sp[1]);
                string author = sp[2];
                books.Add(new Book(title, price, author));
            }
            reader.Dispose();
        }
       
   }
}
