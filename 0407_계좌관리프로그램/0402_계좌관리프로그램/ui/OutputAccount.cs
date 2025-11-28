using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class OutputAccount
    {
        public void Invoke() //p134
        {
            Console.WriteLine("\n[계좌 출금]\n");

            try
            {
                int number = WbLib.InputInteger("계좌번호 입력");
                int balance = WbLib.InputInteger("출금액 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountOutput(number, balance);
                Console.WriteLine("계좌 출금 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
