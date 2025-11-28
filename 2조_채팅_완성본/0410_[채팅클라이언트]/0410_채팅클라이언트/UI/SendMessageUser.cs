using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class SendMessageUser
    {
        public static void Invoke(string message)
        {
            try
            {
                UserControl con = UserControl.Singleton;
                con.UserSendMessage(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[SendMessage ERROR ] : " + ex.Message);
            }
        }
    }
}
