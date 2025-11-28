using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class DeleteUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[회원 탈퇴]\n");

            try
            {
                string name = WbLib.InputString(" 이름 입력 ");

                UserControl con = UserControl.Singleton;
                con.UserDelete(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Delete ERROR ] : " + ex.Message);
            }
        }
    }
}
