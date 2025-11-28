using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0415_데이터베이스
{
    internal class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Balance { get; private set; }
        public DateTime Time { get; private set; }

        public Account() { }
        public Account(int id, string name, int balance, DateTime time)
        {
            Id      = id;
            Name    = name;
            Balance = balance;
            Time    = time;
        }

        public override string ToString()
        {
            return string.Format($"{Id}:{Name}:{Balance}:{Time}");
        }
    }
}
