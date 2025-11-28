using System;
using _0407_MyDll;
using System.Windows.Forms;

namespace _0407_어셈블리이해
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageBox.Show("test", "타이틀바", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Cal1 cal = new Cal1(10, 20);
            cal.Add(); Console.WriteLine(cal.Result);
            cal.Sub(); Console.WriteLine(cal.Result);

            cal.Num1 = 100;
            cal.Num2 = 200;
            cal.Add(); Console.WriteLine(cal.Result);
            cal.Sub(); Console.WriteLine(cal.Result);
        }
    }
}
