using System;

namespace _0401
{
    internal class Member
    {
        private string name;
        private string phone;

        public Member(string _name, string _phone)
        {
            this.name = _name;
            this.phone = _phone;
        }

        public void Print()
        {
            Console.WriteLine(name + "\t" + phone);
        }

        public override string ToString()
        {
            return name + "\t" + phone;
        }

        public override bool Equals(object obj)
        {
            Member _member = (Member)obj;
            return (name == _member.name && phone == _member.phone);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Member member1 = new Member("홍길동", "010-1111-1111");
            member1.Print();
            Console.WriteLine(member1.ToString());
            Console.WriteLine(member1);  //member1.ToString()

            Member member2 = new Member("홍길동", "010-1111-1111");

            if (member1 == member2) //저장된 주소 비교!!
            {
                Console.WriteLine("동일하다");
            }

            if (member1.Equals(member2) == true)
            {
                Console.WriteLine("동일하다111111");
            }

        }
    }
}
