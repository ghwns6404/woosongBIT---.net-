//Account.cs
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
    internal class Customer
    {
        public int CNumber { get; set; } //고객번호
        public string Cname { get; set; }
        public string CPhone { get; set; }
        public string CAddr { get; set; }
       

        //생성자 없음...
        public override string ToString()
        {
            return Cname + ", " + CPhone + ", " + CAddr;
        }
    }

}
