//DeleteAccount.cs
using System;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal static class DeleteAccount
    {
        public static void Invoke() 
        {
            Console.WriteLine("\n[계좌 삭제]\n");

            try
            {
                int number = WbLib.InputInteger("계좌번호 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountDelete(number);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
