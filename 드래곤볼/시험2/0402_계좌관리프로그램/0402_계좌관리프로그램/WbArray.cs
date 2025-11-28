//wbarray.cs
using System;
using System.Collections.Generic;
using System.Xml.Schema;
using WoosongBit41.Data;


namespace WoosongBit41.Lib
{
    internal class BookArray
    {
        private List<Book> books = new List<Book>();  // 동적 배열의 주소 저장(저장소)       
        #region 1. 맴버 필드 및 프로퍼티, 배열의 인덱서

        public int Max
        {
            get;  private set;
        }
        public int Size
        {
            get { return books.Count; }
        }

        public Book this[int idx]
        {
            get
            {
                if (idx < 0 || idx >= books.Count)
                    return null;
                return books[idx];
            }
        }
        #endregion

  
        #region 2. 생성자 
        public BookArray(int max = 10)
        {
            Max = max;
        }
        #endregion

        #region 기능 메서드
        public void Add(Book value)
        {
            if(value != null)
             books.Add(value);
        }
        public void RemoveIdx(int idx)  //Remove
        {
            if (idx < 0 || idx >= Size)
                throw new Exception("잘못된 인덱스 입니다.");
            books.RemoveAt(idx); // 인덱스로 삭제
        }

        public List<Book> get_Books()
        {
            return books;
        }
        #endregion
    }
}
