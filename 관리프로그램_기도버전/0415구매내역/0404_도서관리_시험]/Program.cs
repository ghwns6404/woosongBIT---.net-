using System;

namespace _0404_도서관리_시험_
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
