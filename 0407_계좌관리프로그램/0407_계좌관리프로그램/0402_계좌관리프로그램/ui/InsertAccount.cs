using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    //사용자 입력 -> 메니저 호출
    internal class InsertAccount
    {
        public void Invoke() //p134
        {
            Console.WriteLine("\n[계좌 저장]\n");
  
            try
            {
                int number = WbLib.InputInteger("계좌번호 입력");
                string name = WbLib.InputString("이름 입력");
                int balance = WbLib.InputInteger("입금액 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountInsert(number, name, balance);
                Console.WriteLine("계좌 저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
