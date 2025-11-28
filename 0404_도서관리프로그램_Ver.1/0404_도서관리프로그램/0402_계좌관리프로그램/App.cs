//App.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0404_도서관리프로그램
{
    internal class App
    {
        private BookControl book_control = BookControl.Singleton;

        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        #endregion

        public void Init()  
        {
           book_control.Init();
            WbLib.Logo();   
        }


        public void Run()
        {
            while (true)
            {
                Console.Clear();
                switch (WbLib.MenuPrint())
                {
                    case ConsoleKey.Escape: return; 
                    case ConsoleKey.F1: book_control.BookInsert();     break;   //ㅇㅋ
                    case ConsoleKey.F2: book_control.BookSelect();     break;   //ㅇㅋ
                    case ConsoleKey.F3: book_control.BookUpdate();     break;   //ㅇㅋ
                    case ConsoleKey.F4: book_control.BookDelete();     break;   //ㅇㅋ
                    case ConsoleKey.F5: book_control.SelectNameAll();  break;   //ㅇㅋ
                    default: Console.WriteLine("잘못 입력하셨습니다.");      break;
                }
                WbLib.Pause();
            }
        }

        public void Exit()
        {
            WbLib.Ending();
            book_control.Exit();
        }

    }
}

