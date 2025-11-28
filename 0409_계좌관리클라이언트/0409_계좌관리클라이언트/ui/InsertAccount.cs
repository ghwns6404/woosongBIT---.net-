//InsertAccount.cs
using System;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    //사용자 입력 -> 메니저 호출
    internal static class InsertAccount
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[계좌 저장]\n");

            try
            {
                int number  = WbLib.InputInteger("계좌번호 입력");
                string name = WbLib.InputString("이름 입력");
                int balance = WbLib.InputInteger("입금액 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountInsert(number, name, balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
