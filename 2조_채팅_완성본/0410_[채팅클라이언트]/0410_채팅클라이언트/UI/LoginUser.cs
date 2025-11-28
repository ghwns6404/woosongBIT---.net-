using _0410_채팅클라이언트;
using System;
using System.Xml.Linq;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class LoginUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[로그인]\n");

            try
            {
                string name = WbLib.InputString("이름 입력");

                UserControl con = UserControl.Singleton;
                con.UserLogin(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[로그인 ERROR ] : " + ex.Message);
            }
        }
    }
}
