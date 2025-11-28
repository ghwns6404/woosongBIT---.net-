//App.cs
using System;
using System.Threading;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal class App
    {
        #region 0. 싱글톤 패턴
        public static App Singleton { get; } = null;
        static App() { Singleton = new App(); }
        private App() { }
        #endregion

        public void Init()
        {
            AccountControl.Singleton.Init();
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
                    case ConsoleKey.F1: InsertAccount.Invoke();         break;
                    case ConsoleKey.F2: SelectAccount.Invoke();         break;
                    case ConsoleKey.F3: InputOutputAccount.Invoke();    break;
                    case ConsoleKey.F4: InputAccount.Invoke();          break;
                    case ConsoleKey.F5: OutputAccount.Invoke();         break;
                    case ConsoleKey.F6: DeleteAccount.Invoke();         break;
                    case ConsoleKey.F7: PrintAllAccount.Invoke();      break;
                    default: Console.WriteLine("잘못 입력하셨습니다."); break;
                }
                Thread.Sleep(1000); //서버로부터 데이터 수신 -> 출력
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
