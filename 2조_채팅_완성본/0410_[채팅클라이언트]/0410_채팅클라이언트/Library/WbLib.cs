//WbLib.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using WoosongBit41.ClientNet;

namespace WoosongBit41.Lib
{
    internal static class WbLib
    {
        public static List<string>msgs = new List<string>();

        private const int TOPMESSAGEPOS = 8;

        #region 메세지 내역
        public static string Msg
        {
            set
            {
                if(msgs.Count > 19)
                {
                    msgs.RemoveAt(0); // 리스트에 저장 최대 갯수 = 19개
                }
                msgs.Add(value);
            }
        }
        // 리스트 비우기
        public static void MsgClear()
        {
            msgs.Clear();
        }
        #endregion

        #region 1. 로고, 메뉴, 종료출력 메시지
        public static void Pause()
        {
            Console.ReadKey(true);
        }
        public static void Logo()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine(" 2025년 2학기 우송비트고급41기");
            Console.WriteLine(" C#언어");
            Console.WriteLine(" 채팅 프로그램");
            Console.WriteLine(" 2025-04-10");
            Console.WriteLine(" ccm");
            Console.WriteLine("*************************************************************************");
            Pause();
        }
        public static ConsoleKey First_Screen()
        {
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1] 회원가입 ");
            Console.WriteLine("[F2] 로그인");
            Console.WriteLine("[F3] 회원 탈퇴");
            Console.WriteLine("*************************************************************************");
            return Console.ReadKey().Key;
        }
        public static ConsoleKey Second_Screen()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("이름 : {0}",  (MyClient.MyUser.Name?? "로그인이 안됐습니다.") );
            Console.WriteLine("[ESC] 프로그램 종료");
            Console.WriteLine("[F1]  상대방 탐색");
            Console.WriteLine("[F2]  메세지 전송");
            Console.WriteLine("*************************************************************************");
            return Console.ReadKey().Key;
        }
        public static string Third_Screen()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("[나가기] 입력시 채팅방 나가기");
            Console.WriteLine("[공지사항:  (보낼 내용)] -> 전체메세지 전송");
            Console.WriteLine($"[ 공지사항 ]  {(MyClient.Notice ?? "없습니다")}");
            Console.WriteLine("*************************************************************************");

            Console.WriteLine("\n");
            Console.WriteLine("****************************************************************************************");
            for(int i=0; i<20; i++)     // 19 개의 메세지를 표시 하는 메세지 창
            {
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t\t\t|");
            }
            Console.WriteLine("****************************************************************************************");
            Console.Write(">> ");

            DrowMessage();

            return Console.ReadLine();
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
        public static bool InputBool(string msg)
        {
            Console.WriteLine(msg + ":");
            return TrueOrFalse();
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



        private static bool TrueOrFalse()
        {
            ConsoleKeyInfo flag = new ConsoleKeyInfo();
            while (true)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("[F9] 예 (F9키 두번!!)");
                Console.WriteLine("[F10] 아니요(F10키 두번!!)");
                flag = Console.ReadKey();
                if (flag.Key == ConsoleKey.F9 || flag.Key == ConsoleKey.F10) break;
            }
            return flag.Key == ConsoleKey.F9;
        }
        #endregion

        #region 3. 메세지 출력
        // 메세지 내역
        public static void DrowMessage()
        {
            Thread.Sleep(10);

            int now_x_pos = Console.CursorLeft;
            int now_y_pos = Console.CursorTop;

            if (now_y_pos < 20) // 3번째 화면이 아닐 시 출력 안함.
                return;

            int i = TOPMESSAGEPOS;

            foreach(string msg in msgs)
            {
                Console.SetCursorPosition(2, i++);
                Console.WriteLine(msg);
            }

            Console.SetCursorPosition(now_x_pos, now_y_pos);
        }
        // 상대방 나간 메세지
        public static void ExitMessage()
        {
            Thread.Sleep(10);

            int now_y_pos = Console.CursorTop;

            if (now_y_pos < 20) // 3번째 화면이 아닐 시 출력 안함.
                return;

            Console.SetCursorPosition(2, now_y_pos);
            Console.WriteLine(" 상대방이 나갔습니다.");
        }
        // 공지사항
        #endregion
    }
}
