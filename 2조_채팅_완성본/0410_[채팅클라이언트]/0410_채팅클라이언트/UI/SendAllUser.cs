using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class SendAllUser
    {
        public static void Invoke(string message)
        {
            //Console.WriteLine("\n[공지사항 보내기]\n");
            try
            {
                UserControl con = UserControl.Singleton;
                con.UserSendAll(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SendAll ERROR ] : " + ex.Message);
            }
        }
    }
}
