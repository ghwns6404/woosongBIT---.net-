using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0401
{
    //객체를 한개만 생성한다. -> Gof 디자인패턴 중 싱글톤 패턴
    class Sample
    {
        #region 싱글톤 패턴
        public static Sample Singleton { get; } = null;
        static Sample()   { Singleton = new Sample();    }                    
        private Sample() { }
        #endregion
    
        public void Function() { Console.WriteLine("사용!"); }
    }

    internal class Start
    {
        static void Main(string[] args)
        {
            Sample s1 = Sample.Singleton;
            s1.Function();
            Sample s2 = Sample.Singleton;
            Sample s3 = Sample.Singleton;
            if( ReferenceEquals(s1,s2) == true)
            {
                Console.WriteLine("같은 객체");
            }
        }
    }
}
