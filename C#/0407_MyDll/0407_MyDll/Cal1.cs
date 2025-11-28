using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0407_MyDll
{
    public class Cal1
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Result { get; private set; }

        public Cal1(int num1 = 0, int num2 = 0)
        {
            Num1 = num1;
            Num2 = num2;
            Result = 0;
        }

        public void Add()
        {
            Result = Num1 + Num2;
        }

        public void Sub()
        {
            Result = Num1 - Num2;
        }
    }
}
