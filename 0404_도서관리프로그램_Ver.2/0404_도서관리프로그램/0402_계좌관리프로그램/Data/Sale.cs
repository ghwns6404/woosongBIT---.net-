using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _0402_계좌관리프로그램
{
    internal class Sale
    {
        public int Sid { get; set; } //판매번호
        public int Cid { get; set; } //고객번호
        public int Pid { get; set; } //도서번호
        public int Count { get; set; } //수량
        public string Datetime  { get; set; }   //언제 샀는지
        

        //쓰는건가?
        public int Total_count { get; set; } //판매량 

        public override string ToString()
        {
            return Sid + ", " + Cid + ", " + Pid + ", " + Count + ", " + Datetime;
        }
    }
}
