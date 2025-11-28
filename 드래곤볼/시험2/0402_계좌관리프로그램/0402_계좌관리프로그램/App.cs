//App.cs
using System;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class App
    {
        private BookControl acc_control = BookControl.Singleton;

        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() {}
        #endregion

        public void Init()
        {
            acc_control.Init();
            WbLib.Logo();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                acc_control.BookPrintAll();
                switch (WbLib.MenuPrint())
                {
                    case ConsoleKey.Escape: return; 
                    case ConsoleKey.F1: acc_control.InsertBook();    break;          //저장
                    case ConsoleKey.F2: acc_control.SelectBook();     break;      //검색
                    case ConsoleKey.F3: acc_control.UpdateBook();    break;      //수정
                    case ConsoleKey.F4: acc_control.DeleteBook();     break;      //삭제
                    case ConsoleKey.F5: acc_control.BookPrintAll();    break;      //전체출력
                    case ConsoleKey.F6: acc_control.SortBook();    break;          //정렬
                   
                    default: Console.WriteLine("잘못 입력하셨습니다."); break;
                }
                WbLib.Pause();
            }
        }

        public void Exit()
        {
            acc_control.Exit();
            WbLib.Ending();
        }
    }
}
