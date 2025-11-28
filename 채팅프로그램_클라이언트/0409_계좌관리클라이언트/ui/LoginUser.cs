//LoginUser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    class LoginUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[로그인]\n");
            try
            {
                string name = WbLib.InputString("이름 입력");
               
               

                UserControl con = UserControl.Singleton;
                con.LoginUser(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
