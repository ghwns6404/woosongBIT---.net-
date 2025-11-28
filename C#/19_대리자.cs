using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal delegate void Del(int result);

    internal class Sample
    {
        //프로퍼티
        public Del DelFunc { get; set; } = null;

        public int Add(int x, int y)        {  return x + y; }
        public void Sub(int x, int y)         
        { 
            int result = x - y;

            //callback 호출
            if (DelFunc != null)
            {
                DelFunc.Invoke(result);     //명시적 호출
                DelFunc(result);            //암시적 호출
            }
            else
            {
                Console.WriteLine("Callback 함수 등록 필요");
            }
        }
    }

    internal class Start
    {
        //callback 함수
        static void Result(int result)
        {
            Console.WriteLine("CallBack : " + result);
        }
        static void Main(string[] args)
        {
            Sample s1 = new Sample();
            Console.WriteLine(s1.Add(1, 2));

            //s1.DelFunc = new Del(Result);
            s1.DelFunc = Result;

            s1.Sub(1, 2);
        }
    }
}
