//App.cs
using System;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class App
    { 
        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() {}
        #endregion

        public void Init()
        {
            AccountControl.Singleton.Init();
            WbLib.Logo();
        }

        public void Run()
        {
            PrintAllAccount p_account = new PrintAllAccount();
            while (true)
            {
                Console.Clear();
                p_account.Invoke();                
                switch (WbLib.MenuPrint())
                {
                    case ConsoleKey.Escape: return; 
                    case ConsoleKey.F1: new InsertAccount().Invoke();    break;
                    case ConsoleKey.F2: new SelectAccount().Invoke();    break;
                    case ConsoleKey.F3: new SelectNameAll().Invoke();    break;
                    case ConsoleKey.F4: new InputAccount().Invoke();     break;
                    case ConsoleKey.F5: new OutputAccount().Invoke();    break;
                    case ConsoleKey.F6: new DeleteAccount().Invoke();    break;
                    default: Console.WriteLine("잘못 입력하셨습니다."); break;
                }
                WbLib.Pause();
            }
        }

        public void Exit()
        {
            AccountControl.Singleton.Exit();
            WbLib.Ending();
        }
    }
}
