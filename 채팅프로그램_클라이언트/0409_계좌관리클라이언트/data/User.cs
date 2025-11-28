//User.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0409_계좌관리클라이언트
{
    internal class User
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        public string Name { get; private set; }
        
        #endregion

        #region 2. 생성자
        public User(string _name, string _id, string _pw)
        {
            Name = _name;
            
        }
        #endregion
        public User(string name)
        {
            Name = name;
        }

        #region 3.기능 메서드
        public void Print()
        {
            Console.Write("접속자 : "+ Name + "\t");
            //Console.Write(Id + "\t");
            //Console.Write(Pw + "\t");
            Console.WriteLine();
        }

        #endregion
    }
}
