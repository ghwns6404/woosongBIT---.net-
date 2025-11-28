using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal class Sample
    {
    }

    internal class Start
    {

        static void Main(string[] args)
        {
            Sample s1 = new Sample(); //객체(인스턴스) 생성                
            Sample s2 = new Sample(); //객체(인스턴스) 생성

            Console.WriteLine(s1);  //1000
            Console.WriteLine(s2);  //1010

            Sample.s_Function();
            s1.Function();
        }
    }
}


