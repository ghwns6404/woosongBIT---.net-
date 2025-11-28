using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class InsertUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[회원 가입]\n");

            try
            {
                string name = WbLib.InputString("닉네임 입력");

                UserControl con = UserControl.Singleton;
                con.UserInsert(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[회원 가입 ERROR ] : " + ex.Message);
            }
        }
    }
}
