using System;
using WoosongBit41.Lib;

namespace _0404_도서관리_시험_ //이것도 이름 바꿀것
{
    internal class App
    {
        private SaleControl acc_control = SaleControl.Singleton;

        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() { }
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
                acc_control.SalePrintAll();
                acc_control.BookPrintAll();
                acc_control.MemberPrintAll();
                switch (WbLib.MenuPrint())
                {
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F1: acc_control.SaleInsert(); break;
                    case ConsoleKey.F2: acc_control.SelectSale(); break;
                    case ConsoleKey.F3: acc_control.SaleUpdate(); break;
                    case ConsoleKey.F4: acc_control.SaleDelete(); break;
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
