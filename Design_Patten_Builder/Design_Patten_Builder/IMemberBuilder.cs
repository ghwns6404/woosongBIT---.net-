using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patten_Builder
{
    internal interface IMemberBuilder
    {
        IMemberBuilder CreateId(int id);
        IMemberBuilder CreateName(string name);
        IMemberBuilder CreatePhone(string phone);
        IMemberBuilder CreateAge(int age);
        IMemberBuilder CraeteAddr(string addr);
        IMemberBuilder CreateBirth(DateTime dt);
        IMemberBuilder CreateFamilyCount(int count);

        Member Build();
    }
}
