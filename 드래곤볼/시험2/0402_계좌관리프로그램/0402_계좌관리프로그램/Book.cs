//Account.cs
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
    internal class Book : IComparable
    {
        private List<Book> books = new List<Book>();  // 동적 배열의 주소 저장(저장소)       
    
        #region 1. 맴버필드, 프로퍼티(속성)
        public string Title { get; private set; }
        public int Price    { get; set; }
        public string Author { get; private set; }

        #endregion

        #region 2. 생성자
        public Book(string _title, int _price, string _author)
        {
            Title = _title;
            Price = _price;
            Author = _author;
        }
        #endregion

        #region 3. 기능 메서드
        public void Print()
        {
            Console.WriteLine();
            Console.Write("도서명 : " + Title + "\t");
            Console.Write("가격 : " + Price + "\t");
            Console.Write("저자 : " + Author + "\t");
            Console.WriteLine();
        }
        public void Println()
        {
            Console.WriteLine();
            Console.Write("도서명 : " + Title + "\t");
            Console.Write("가격 : " + Price + "\t");
            Console.Write("저자 : " + Author + "\t");
            Console.WriteLine();
        }
        #endregion

        #region 4. 정렬
        public int CompareTo(object obj)
        {
            Book book = (Book)obj;
            return Title.CompareTo(book.Title);
        }
        #endregion
    }
}
