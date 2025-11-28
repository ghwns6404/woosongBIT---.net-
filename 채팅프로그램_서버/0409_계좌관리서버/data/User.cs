//Account.cs
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
    internal class User
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        public string Name { get; private set; }
        public string Id { get; private set; }
        public string Pw { get; private set; }

        #endregion

        #region 2. 생성자
        public User(string _name, string _id, string _pw)
        {
            Name = _name;
            Id = _id;
            Pw = _pw;
        }
        public User(string _name)
        {
            Name = _name;
            Id = "";
            Pw = "";
        }
        #endregion

        #region 3.기능 메서드
        public void Print()
        {
            Console.Write("접속자 : " + Name + "\t");
            //Console.Write(Id + "\t");
            //Console.Write(Pw + "\t");
            Console.WriteLine();
        }

        #endregion
    }
}
