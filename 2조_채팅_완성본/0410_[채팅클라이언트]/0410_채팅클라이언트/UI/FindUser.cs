using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class FindUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[통신 대상 입력]\n");

            try
            {
                // 통신하고 싶은 대상 이름 입력
                string name = WbLib.InputString("닉네임 입력");

                UserControl con = UserControl.Singleton;
                con.UserFind(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[FindUser ERROR ] : " + ex.Message);
            }
        }
    }
}
