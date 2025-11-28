//InputOutputAccount.cs
using System;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal class InputOutputAccount
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[계좌 이체]\n");
            try
            {
                int input_number    = WbLib.InputInteger("입금 계좌번호 입력");
                int output_number   = WbLib.InputInteger("출금 계좌번호 입력");
                int money           = WbLib.InputInteger("이체금액 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountInputOutput(input_number, output_number, money);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
