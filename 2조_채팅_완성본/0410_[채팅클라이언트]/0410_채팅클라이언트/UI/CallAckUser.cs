using _0410_채팅클라이언트;
using System;
using WoosongBit41.Lib;

namespace WoosongBit41.UI
{
    internal static class CallAckUser
    {
        public static void Invoke(string name)
        {
            Console.WriteLine("\n[대화 연결 요청 받음]\n");
            try
            {
                Console.SetCursorPosition(0, 7);
                bool flag = WbLib.InputBool($"{name} 과 대화 하시겠습니까?");
                Console.SetCursorPosition(0, 0);

                UserControl con = UserControl.Singleton;
                con.UserCallAck(flag , name);
            }
            catch (Exception ex)
            {
                Console.SetCursorPosition(30 , 3);
                Console.WriteLine("[회원 가입 ERROR ] : " + ex.Message);
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
