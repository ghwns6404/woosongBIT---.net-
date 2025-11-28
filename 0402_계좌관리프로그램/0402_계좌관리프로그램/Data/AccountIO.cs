//AccountIO.cs
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
    internal class AccountIO
    {
        #region 1. 맴버필드, 프로퍼티(속성)
        
        public int Input { get; private set; }
        public int Output { get; private set; } //
        public int Balance { get; private set; }
        public DateTime CTime { get; private set; }
        #endregion

        #region 2. 생성자
        public AccountIO(int _input, int _output, int _balance)
        {
            
            Input = _input;
            Output = _output;
            Balance = _balance;
            CTime = DateTime.Now;
        }
        public AccountIO(int _input, int _output, int _balance, DateTime _ctime)
        {
           
            Input = _input;
            Output = _output;
            Balance = _balance;
            CTime = _ctime;
        }
        
        #endregion

        #region 3. 기능 메서드
        public void Print()
        {
            Console.Write("{0,10}원 {1,10}원 {2,10}원",  Input, Output, Balance);
            Console.Write("\t{0} {1}", WbLib.Get_Date(CTime), WbLib.Get_Time(CTime));
            Console.WriteLine();
        }
        #endregion
    }
}
