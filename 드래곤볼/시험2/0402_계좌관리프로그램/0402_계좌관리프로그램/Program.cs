//계좌관리프로그램 - 정렬 기능  추가
using System;
using WoosongBit41.Lib;
using static System.Net.Mime.MediaTypeNames;

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
        }
    }
}
