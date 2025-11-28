//도서
using System;

namespace _0404_도서관리프로그램_V2
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            App app = App.Singleton;
            app.Init();
            app.Run();
            app.Exit();
        }
    }
}
