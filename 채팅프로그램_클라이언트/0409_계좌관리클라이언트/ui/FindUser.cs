//FindUser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    class FindUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[연결하고싶은 유저 검색하기]\n");

            try
            {
                string name = WbLib.InputString("연결 할 유저 이름 입력 : ");

                UserControl con = UserControl.Singleton;
                con.UserFind(name);
                //Console.WriteLine("상대방과 연결성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
