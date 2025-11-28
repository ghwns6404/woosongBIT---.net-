using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patten_Builder
{
    internal class Member
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public int Age { get; private set; }
        public string Addr { get; private set; }
        public DateTime Birth { get; private set; }
        public int FamilyCount { get; private set; }

        public Member(int id, string name, string phone, int age, string addr, DateTime birth)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Age = age;
            Addr = addr;
            Birth = birth;
        }

        public override string ToString()
        {
            return $"ID: {Id}\nName: {Name}\nPhone: {Phone}\nAge: {Age}\nAddr: {Addr}\nBirth: {Birth}\nCount: {FamilyCount}";
        }
    }
}
