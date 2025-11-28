using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class SelectAccount
    {
        public void Invoke() //p134
        {
            Console.WriteLine("\n[계좌 검색]\n");

            try
            {
                int number = WbLib.InputInteger("계좌번호 입력");

                AccountControl con  = AccountControl.Singleton;
                Account account     = con.NumberToAccount(number);
                account.Println();

                Console.WriteLine("--------------------------------------------");
                con.AccountIOPrint(number);
                Console.WriteLine("--------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
