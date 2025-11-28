using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;
using 채팅프로그램_클라이언트;

namespace _0409_계좌관리클라이언트
{
    class DeleteUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[유저 삭제]\n");

            try
            {
                string name = WbLib.InputString("삭제할 입력");

                UserControl con = UserControl.Singleton;
                con.UserDelete(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
