using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace _0401
{
    internal delegate int DelFunc(string msg, int a, int b);  //비동기 호출할 대상의 함수

    internal class Sample
    {
        //동기방식
        public void Example1()
        {
            int result1 = Sum("첫번째 호출", 0, 300);
            int result2 = Sum("두번째 호출", 0, 200);
            int result3 = Sum("세번째 호출", 0, 100);

            Console.WriteLine(result1 + ", " + result2 + ", " + result3);
        }

        //비동기 방식 -> 대리자 사용!
        public void Example2()
        {
            DelFunc f1 = Sum;
            DelFunc f2 = Sum;
            DelFunc f3 = Sum;

            f1.BeginInvoke("f1", 0, 100, EndSum, "f1");
            f2.BeginInvoke("f2", 0, 100, EndSum, "f2");
            f3.BeginInvoke("f3", 0, 100, EndSum, "f3");

            Console.ReadLine(); //대기
        }

        public void EndSum(IAsyncResult iar)
        {
            string str = (string)iar.AsyncState;  //BeginInvoke 마지막 인자 전달 정보
            Console.WriteLine(str);

            AsyncResult ar  = iar as AsyncResult;
            DelFunc dele    = ar.AsyncDelegate as DelFunc;
            int result = dele.EndInvoke(ar);
            Console.WriteLine(result);
        }

        //연산 함수
        private int Sum(string msg, int n1, int n2)
        {
            int sum = 0;
            for(; n1 <=n2; n1++)
            {
                sum = sum + n1;
                Console.WriteLine("{0} -> Sum{1}", msg, n1);
                Thread.Sleep(100); //0.1
            }
            return sum;
        }
    }

    internal class Start
    {
        static void Main(string[] args)
        {
            Sample s1 = new Sample();
            s1.Example2();
        }
    }
}
