//App.cs

using System;
using WoosongBit41.Lib;

namespace _0404_도서관리프로그램_V2
{
    internal class App
    {
        private CustControl cust_control = CustControl.Singleton;
        private BookControl book_control = BookControl.Singleton;
        private SaleControl sale_control = SaleControl.Singleton;

        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        #endregion

        public void Init()
        {
            cust_control.Init();
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
                    case ConsoleKey.F1: book_control.BookInsert(); break;   //ㅇㅋ
                    case ConsoleKey.F2: book_control.BookSelect(); break;   //ㅇㅋ
                    case ConsoleKey.F3: book_control.BookUpdate(); break;   //ㅇㅋ
                    case ConsoleKey.F4: book_control.BookDelete(); break;   //ㅇㅋ
                    case ConsoleKey.F5: book_control.SelectNameAll(); break;   //ㅇㅋ

                    case ConsoleKey.F6: cust_control.CustomerInsert(); break;   //ㅇㅋ
                    case ConsoleKey.F7: cust_control.CustomerSelect(); break;   //ㅇㅋ
                    case ConsoleKey.F8: cust_control.CustomerUpdate(); break;   //ㅇㅋ
                    case ConsoleKey.F9: cust_control.CustomerDelete(); break;   //ㅇㅋ
                    case ConsoleKey.F10: cust_control.SelectCustomerAll(); break;   //ㅇㅋ

                    case ConsoleKey.Z: sale_control.SaleUpdateCount(); break;   //ㅇㅋ
                    case ConsoleKey.X: sale_control.SaleDeleteCount(); break;   //ㅇㅋ
                    case ConsoleKey.C: sale_control.SaleSelectMax();   break;   //ㅇㅋ
                    case ConsoleKey.V: sale_control.SaleSelectLog(); break;   //ㅇㅋ
                    //case ConsoleKey.V: cust_control.CustomerDelete(); break;   //ㅇㅋ
                    //case ConsoleKey.B: cust_control.SelectCustomerAll(); break;   //ㅇㅋ
                    //default: Console.WriteLine("잘못 입력하셨습니다."); break;
                }
                WbLib.Pause();
            }
        }

        public void Exit()
        {
            WbLib.Ending();
            cust_control.Exit();
        }

    }
}

