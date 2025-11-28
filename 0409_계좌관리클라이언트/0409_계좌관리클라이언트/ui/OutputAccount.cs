//OutputAccount.cs
using System;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal static class OutputAccount
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[계좌 출금]\n");

            try
            {
                int number  = WbLib.InputInteger("계좌번호 입력");
                int balance = WbLib.InputInteger("출금액 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountOutput(number, balance);               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
