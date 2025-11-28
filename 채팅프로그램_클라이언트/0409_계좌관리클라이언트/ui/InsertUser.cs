//InsetUser.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;

namespace 채팅프로그램_클라이언트
{
    class InsertUser
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[유저 생성]\n");
            try
            {
                //string id = WbLib.InputString("아이디 입력");
                //string pw = WbLib.InputString("비밀번호 입력");
                string name = WbLib.InputString("이름 입력");

                UserControl con = UserControl.Singleton;
                con.UserInsert(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
