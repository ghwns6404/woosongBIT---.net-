//CallUser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;
using 채팅프로그램_클라이언트;

namespace 채팅프로그램_클라이언트
{
    class CallUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[call user]\n");

            try
            {
                string name = WbLib.InputString("");

                UserControl con = UserControl.Singleton;
                con.UserCall(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
