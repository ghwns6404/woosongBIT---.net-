//Account.cs
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.Data
{
    internal class Book
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        

        //생성자 없음...
        public override string ToString()
        {
            return Number + ", " + Name + ", " + Price + ", " + Description;
        }
    }

}
