using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patten_Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MemberBuilder builder = new MemberBuilder();
            Member member = builder.CreateId(10)
                                .CreateName("홍길동")
                                .CreatePhone("010-1111-1111")
                                .CreateAge(20)
                                .CraeteAddr("우송비트")
                                .CreateBirth(DateTime.Now)
                                .Build();
            Console.WriteLine(member);
        }
    }
}
