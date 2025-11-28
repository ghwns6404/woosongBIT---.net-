//Program.cs

using System;
using WoosongBit41.Lib;

namespace 채팅프로그램_서버
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = App.Singleton;
            app.Init();
            Console.Clear();
            Console.ReadLine();
            app.Exit();
        }
    }
}
