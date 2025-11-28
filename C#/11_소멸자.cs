using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal class Sample : IDisposable
    {
        public Sample()
        {
            Console.WriteLine("[외부자원] DB에 연결");
        }
        ~Sample()
        {
            Dispose();
        }

        public void Dispose()
        {
            Console.WriteLine("[외부자원] Dispose- DB연결 종료");
            GC.SuppressFinalize(this);
        }
    }

    internal class Start
    {
        static void fun()
        {
            Sample s1 = new Sample();
            s1.Dispose();
        }
        static void Main(string[] args)
        {
            fun();
            //Console.ReadKey();                     
        }
    }
}
