//SelectAccount.cs
using System;
using System.Xml.Linq;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal static class SelectAccount
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[계좌 검색]\n");

            try
            {
                int number = WbLib.InputInteger("계좌번호 입력");

                AccountControl con = AccountControl.Singleton;
                con.AccountSelect(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
