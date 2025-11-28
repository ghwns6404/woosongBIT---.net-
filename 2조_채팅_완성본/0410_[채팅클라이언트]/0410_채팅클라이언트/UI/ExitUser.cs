using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class ExitUser
    {
        public static void Invoke()
        {
            //Console.WriteLine("\n[채팅방 나가기]\n");
            try
            {
                UserControl con = UserControl.Singleton;
                con.UserExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[채팅방 나가기 ERROR ] : " + ex.Message);
            }
        }
    }
}
