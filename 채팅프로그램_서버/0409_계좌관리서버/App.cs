//App.cs
using WoosongBit41.Lib;

namespace 채팅프로그램_서버
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
            UserControl.Singleton.Init();
            WbLib.Logo();
        }

        public void Exit()
        {
            UserControl.Singleton.Exit();
            WbLib.Ending();
        }
    }
}
