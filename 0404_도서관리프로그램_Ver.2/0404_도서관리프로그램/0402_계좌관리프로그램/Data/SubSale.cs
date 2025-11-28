using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _0402_계좌관리프로그램
{
    internal class SubSale
    {
        public string Pname { get; set; }
        public string Saledate { get; set; }
        public int Count { get; set; }

        

        public override string ToString()
        {
            return Pname + ", " + Saledate + ", " + Count;
        }
    }
}
