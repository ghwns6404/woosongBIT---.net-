//계좌관리프로그램
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace _0402_계좌관리프로그램
{
    internal class Program
    {
        static void Main(string[] args)
        {
            App app = App.Singleton;
            app.Init();
            app.Run();
            app.Exit();
            App app2 = App.Singleton;
        }
    }
}
