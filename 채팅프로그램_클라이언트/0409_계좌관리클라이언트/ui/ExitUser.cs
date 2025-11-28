//ExitUser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.ClientNet;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    class ExitUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[연결 종료 ]\n");

            try
            {
                UserControl con = UserControl.Singleton;
                con.UserExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
