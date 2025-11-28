using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patten_Builder
{
    internal class MemberBuilder : IMemberBuilder
    {
        #region 멤버필드
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public int Age { get; private set; }
        public string Addr { get; private set; }
        public DateTime Birth { get; private set; }
        public int Count { get; private set; }
        #endregion

        public Member Build()
        {
            return new Member(Id, Name, Phone, Age, Addr, Birth);
        }

        #region 제작자
        public IMemberBuilder CraeteAddr(string addr)
        {
            Addr = addr;
            return this;
        }

        public IMemberBuilder CreateAge(int age)
        {
            Age = age;
            return this;
        }

        public IMemberBuilder CreateBirth(DateTime dt)
        {
            Birth = dt;
            return this;
        }

        public IMemberBuilder CreateId(int id)
        {
            Id = id;
            return this;
        }

        public IMemberBuilder CreateName(string name)
        {
            Name = name;
            return this;
        }

        public IMemberBuilder CreatePhone(string phone)
        {
            Phone = phone;
            return this;
        }

        public IMemberBuilder CreateFamilyCount(int count)
        {
            Count = count;
            return this;
        }
        #endregion
    }
}
