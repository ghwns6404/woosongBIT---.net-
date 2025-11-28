using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 학생관리
{
    internal static class WbLib
    {
        #region 로고출력
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
            Console.WriteLine(" 학생 관리 프로그램");
            Console.WriteLine(" 2025-04-07");
            Console.WriteLine(" ccm");
            Console.WriteLine("*************************************************************************");
            Pause();
        }
        public static ConsoleKey MenuPrint()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 학생정보 삽입");
            Console.WriteLine("[F2] 학생정보 검색");
            Console.WriteLine("[F3] 학생정보 수정");
            Console.WriteLine("[F4] 학생정보 삭제");
            Console.WriteLine("[F5] 학생이름으로 정렬");
            //Console.WriteLine("[F6] 학생정보 전체출력");
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
        #endregion

        #region 입력기능
        public static int InputInteger(string msg)
        {
            Console.Write(msg + " : ");
            return int.Parse(Console.ReadLine());
        }
        public static string InputString(string msg)
        {
            Console.Write(msg + " : ");
            return Console.ReadLine();
        }
        public static float InputFloat(string msg)
        {
            Console.Write(msg + " : ");
            return float.Parse(Console.ReadLine());
        }
        #endregion
    }
}
