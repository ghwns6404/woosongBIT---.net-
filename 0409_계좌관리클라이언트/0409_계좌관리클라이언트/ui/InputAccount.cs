//InputAccount.cs
using System;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal static class InputAccount
    {
        public static void Invoke() 
        {
            Console.WriteLine("\n[계좌 입금]\n");

            try
            {
                int number = WbLib.InputInteger("계좌번호 입력");
                int balance = WbLib.InputInteger("입금액 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountInput(number, balance);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
