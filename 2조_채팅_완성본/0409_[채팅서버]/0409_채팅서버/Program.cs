using System;

namespace _0409_채팅서버
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = App.Singleton;
            app.Init();
            app.Exit();
        }
    }
}
