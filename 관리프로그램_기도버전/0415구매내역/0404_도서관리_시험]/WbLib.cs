using System;

namespace WoosongBit41.Lib
{
    internal class WbLib
    {
        public static void Pause()
        {
            Console.WriteLine("\n\n엔터키를 누르세요");
            Console.ReadLine();
        }
        public static void Logo()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(" 천호준천호준천호준천호준천호준천호준");
            Console.WriteLine(" C#언어");
            Console.WriteLine(" 도서 관리 프로그램 시험");
            Console.WriteLine(" 2025-04-18");
            Console.WriteLine(" 테이블 세개 통합본");
            Console.WriteLine("*************************************************************************");
            Pause();
        }
        public static ConsoleKey MenuPrint()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 거래내역 저장");
            Console.WriteLine("[F2] 거래내역 검색 - (SID로 찾기)");
            Console.WriteLine("[F3] 거래내역 수정");
            Console.WriteLine("[F4] 거래내역 삭제");
            Console.WriteLine("*************************************************************************");
            return Console.ReadKey(true).Key;
        }
        public static void Ending()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(" 프로그램을 종료합니다.");
            Console.WriteLine("*************************************************************************");
            Pause();
        }
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

        #region 3. 날짜와 시간을 문자열로 반환
        public static string Get_Date(DateTime time)
        {
            return string.Format("{0:D4}-{1:D2}-{2:D2}", time.Year, time.Month, time.Day);
        }
        public static string Get_Time(DateTime time)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hour, time.Minute, time.Second);
        }
        #endregion
    }
}
