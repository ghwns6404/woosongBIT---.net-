using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal class Sample
    {
        private static int NUMBER;

        //언제나 가장 먼저 한번 호출
        static Sample()
        {
            Console.WriteLine("정적 생성자");
            NUMBER = 10;
        }

        static void Main(string[] args)
        {
            Sample sample = new Sample();
        }
    }
}
