using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0415_데이터베이스
{
    internal class Book
    {
        public int Number {  get; set; }
        public string Name { get; set; }
        public int Price {  get; set; }
        public string Description {  get; set; }

        //생성자 없음...
        public override string ToString()
        {
            return Number + ", " + Name + ", " + Price + ", " + Description;
        }
    }
}
