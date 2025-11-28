//Program
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 학생관리
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

