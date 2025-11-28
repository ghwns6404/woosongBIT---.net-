//Account.cs
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
    internal class Account
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        public int Number       { get; private set; }
        public string Name      { get; private set; }
        public int Balance      { get; private set; }
        public DateTime Time   { get; private set; }
        #endregion

        
        #region 2. 생성자
        public Account(int _number, string _name, int _balance)
        {
            Number  = _number;
            Name    = _name;
            Balance = _balance;
            Time   = DateTime.Now;
        }

        public Account(int _number, string _name, int _balance, DateTime _time)
        {
            Number  = _number;
            Name    = _name;
            Balance = _balance;
            Time   = _time;
        }

     
        #endregion

        #region 3. 기능 메서드
        
        public void Print()
        {
            Console.Write(Number + "\t");
            Console.Write(Name + "\t");
            Console.Write(Balance + "원\t");
            Console.Write(WbLib.Get_Date(Time) + "\t");
            Console.Write(WbLib.Get_Time(Time) + "\t");
            Console.WriteLine();
        }
        public void Println()
        {
            Console.WriteLine("[번호] " + Number);
            Console.WriteLine("[이름] " + Name);
            Console.WriteLine("[잔액] " + Balance + "원");
            Console.WriteLine("[날짜] " + WbLib.Get_Date(Time));
            Console.WriteLine("[시간] " + WbLib.Get_Time(Time));
        }
        public override string ToString()
        {
            return string.Format($"{Number}:{Name}:{Balance}:{Time}");
        }
        #endregion 
    }
}
