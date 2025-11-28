//WbLib.cs
using System;
using System.Security.Policy;
using System.Xml.Linq;

namespace WoosongBit41.Lib
{
    internal static class WbLib
    {
        #region 1. 로고, 메뉴, 종료출력 메시지
        public static void Pause()
        {
            Console.Write("\n\n엔터키를 누르세용..");
            Console.ReadKey(true);
        }

        public static void Logo()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(" 채팅 클라 채팅 클라 채팅 클라 채팅 클라");
            Console.WriteLine(" C#언어");
            Console.WriteLine(" 채팅 프로그램(클라이언트)");
            Console.WriteLine(" 2025-04-09");
            Console.WriteLine(" ccm");
            Console.WriteLine("*************************************************************************");
            Pause();
        }

        public static ConsoleKey MenuPrint1()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료\n");
            Console.WriteLine("[F1] 회원가입");
            Console.WriteLine("[F2] 로그인");
            Console.WriteLine("[F3] 유저 삭제");
            Console.WriteLine("[F4] 돌아가기");
            Console.WriteLine("*************************************************************************");
            return Console.ReadKey().Key;   
        }
        public static ConsoleKey MenuPrint2()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[F1] 1 : 1 유저 선택");
            Console.WriteLine("[F4] 돌아가기");
            Console.WriteLine("*************************************************************************");
            return Console.ReadKey().Key;
        }
        public static ConsoleKey MenuPrint3()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료\n");
            Console.WriteLine("[F1] 1 : 1 메세지보내기");
            Console.WriteLine("[F2] 공지사항");
            Console.WriteLine("[F3] 채팅방 종료");
            Console.WriteLine("[F4] 돌아가기");
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

        //string flag = Write.InputString($"{name} 이 요청헀습니다 .(Yse / No)");

        //public static string InputString 

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

        public static bool InputBool(string msg)
        {
            Console.WriteLine(msg + " (Y: F2 / N: F3");
            while (true)
            {
                var key = Console.ReadKey(true).Key; // 키 입력을 비동기로 읽음
                if (key == ConsoleKey.F2)
                {
                    return true; // F2를 누르면 YES
                }
                else if (key == ConsoleKey.F3)
                {
                    return false; // F3를 누르면 NO
                }
                else
                {
                    Console.WriteLine("Wrong Inser!");
                    Console.WriteLine("F2(Yes)/F3(No)을 누르세요");
                }
            }
        }
        #endregion

        #region 3. 날짜와 시간을 문자열로 반환
        public static string Get_Date(DateTime time)
        {
            return string.Format("{0}-{1}-{2}", time.Year, time.Month, time.Day);
        }
        public static string Get_Time(DateTime time)
        {
            return string.Format("{0}:{1}:{2}", time.Hour, time.Minute, time.Second);
        }
        #endregion
    }
}
