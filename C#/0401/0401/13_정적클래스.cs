
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    //정적 클래스 : 객체 생성 불가
    //관리할 맴버 필드가 없다.
    internal static class Sample
    {
        public static int  Add(int n1, int n2) { return n1+ n2; }
        public static int Sub(int n1, int n2) { return n1 - n2; }
    }

    internal class Start
    {
        static void Main(string[] args)
        {
            Sample.Add(10, 20);
            Sample.Sub(10, 20);
        }
    }
}
