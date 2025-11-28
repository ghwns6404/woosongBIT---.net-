//SendMessageUser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    class SendMessageUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[메세지 보내기]\n");

            try
            {
                string name = WbLib.InputString("내이름:");
                string message = WbLib.InputString("메세지를 입력하세요: ");
                DateTime time = DateTime.Now;

                UserControl con = UserControl.Singleton;
                con.UserSendMessage(name, message, time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
