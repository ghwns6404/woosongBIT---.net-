using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    internal class _06_인자전달
    {
        //인자전달
        static void foo(int n1, ref int n2, out int n3)
        {
            n1 = 11;
            //n2 = 22;  //선택
            n3 = 33;    //강제
        }
        private static void foo1()
        {
            int num1 = 1, num2 = 2, num3 = 3;

            //값전달, ref, out전달
            foo(num1, ref num2, out num3);

            Console.WriteLine(num1 + ", " + num2 + ", " + num3);
        }

        static void fun1()
        {
            try
            {
                Console.Write("정수 입력 : ");
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(num);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void fun2()
        {            
            Console.Write("정수 입력 : ");
            int num;
            if (int.TryParse(Console.ReadLine(), out num) == true)
            {
                Console.WriteLine(num);
            }
            else
            {
                Console.WriteLine("잘못된 입력");
            }
        }
        static void Main(string[] args)
        {
            fun2();
        }        
    }
}
