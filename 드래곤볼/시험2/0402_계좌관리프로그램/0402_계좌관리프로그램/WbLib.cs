//WbLib.cs
using System;

namespace WoosongBit41.Lib
{
    internal static class WbLib
    {
        #region 1. 로고, 메뉴, 종료출력 메시지
        public static void Pause()
        {
            Console.Write("\n\n엔터키를 누르세요..........");
            Console.ReadKey(true);
        }

        public static void Logo()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(" 2025년 2학기 우송비트고급41기");
            Console.WriteLine(" C#언어");
            Console.WriteLine(" 도서 관리 프로그램");
            Console.WriteLine(" 2025-04-02");
            Console.WriteLine(" ccm");
            Console.WriteLine("*************************************************************************");
            Pause();
        }

        public static ConsoleKey MenuPrint()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 도서 저장");
            Console.WriteLine("[F2] 도서 검색");
            Console.WriteLine("[F3] 도서 수정");
            Console.WriteLine("[F4] 도서 삭제");
            Console.WriteLine("[F5] 도서 전체출력");
            Console.WriteLine("[F6] 도서명으로 오름차순 정렬");
            
            Console.WriteLine("*************************************************************************");
            return Console.ReadKey().Key;        
        }

        public static void Ending()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(" 프로그램을 종료합니다.");
            Console.WriteLine("*************************************************************************");
            Pause();
        }
        #endregion

        #region 2. 입력 
        public static int InputInteger(string msg)
        {
            Console.Write(msg + " : ");
            return int.Parse(Console.ReadLine());
        }

        public static float InputFloat(string msg)
        {
            Console.Write(msg + " : ");
            return float.Parse(Console.ReadLine());
        }

        public static char InputChar(string msg)
        {
            Console.Write(msg + " : ");
            return char.Parse(Console.ReadLine());
        }

        public static string InputString(string msg)
        {
            Console.Write(msg + " : ");            
            return Console.ReadLine();
        }
        #endregion

    }
}
