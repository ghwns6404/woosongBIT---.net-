//MyIO.cs
/*
인스턴스맴버 : 생성된 객체(인스턴스)를 이용해 사용하는 맴버
클래스맴버   : 생성된 객체로 사용할 수 없고, 클래스이름으로 사용하는 맴버  
               static이 붙은 맴버
*/
using System;

namespace WoosongBit41.Sample
{
    /// <summary>
    /// 내가 만든 입출력 예제
    /// </summary>
    internal class MyIO
    {
        /// <summary>
        /// WriteLine : 모든 타입별 오버로딩
        ///           : 문자열 형태로 변환 출력
        /// </summary>
        public static void PrintSample()
        {
            Console.WriteLine("Hello, Wrold");
            Console.WriteLine(10);
            Console.WriteLine(10 + "문자열연결" + 20);
            Console.WriteLine(10 + 20 + "문자열연결"); 
        }
        
        //WriteLine : 인덱스 활용
        public static void PrintSample1()
        {
            Console.WriteLine("{0}, {1} 인덱스 활용", 10, 'A');
            Console.WriteLine("{0} + {1} = {2}", 10, 20, 10+20);
            Console.WriteLine("{0} / {1} = {2}", 10, 20, (float)10 / 20);
        }
    
        //Write : 개행 처리가 없음
        //        사용방법은 WriteLine과 동일
        public static void PrintSample2()
        {
            Console.Write("문자열 출력");
            Console.Write("개행 처리는 직접\n");
            Console.Write(10);            
        }
 
        //Console.ReadLine() 문자열 반환
        //기본 데이터 타입 입력
        public static void InputSample1()
        {
            Console.Write("이름 : ");
            string name = Console.ReadLine();

            Console.Write("나이 : ");
            string temp = Console.ReadLine();
            int age     = int.Parse(temp);

            Console.Write("몸무게 : ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("성별(남/여) : ");    //한글도 가능(유니코드)
            char gender = char.Parse(Console.ReadLine());

            Console.WriteLine("\n\n[입력 결과]");
            Console.WriteLine("이름 : " + name);
            Console.WriteLine("나이 : " + age);
            Console.WriteLine("몸무게 : {0}", weight);
            Console.WriteLine("성별 : {0}", gender);
        }

        //Console.ReadKey()
        //특수키 입력시
        public static void InputSample2()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                    Console.WriteLine("UpArrow");
                else if (key.Key == ConsoleKey.DownArrow)
                    Console.WriteLine("DownArow");
                else if (key.Key == ConsoleKey.F1)
                    Console.WriteLine("F1");
                else if (key.Key == ConsoleKey.Escape)
                    Console.WriteLine("Esc");
                else if (key.Key == ConsoleKey.D1)
                    Console.WriteLine("D1");
                else if (key.Key == ConsoleKey.NumPad1)
                    Console.WriteLine("NumPad1");
                else if (key.Key == ConsoleKey.X)
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        { 
            WoosongBit41.Sample.MyIO.PrintSample();
            MyIO.PrintSample();

            System.Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
        }
    }
}
