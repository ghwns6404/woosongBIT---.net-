//PrintAllAccount.cs
using System;
using System.Collections.Generic;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0409_계좌관리클라이언트
{
    internal static class PrintAllAccount
    {
        public static void Invoke()
        {
            Console.WriteLine("\n[계좌 전체 출력]\n");

            try
            {
                AccountControl con = AccountControl.Singleton;
                con.AccountPrintAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Account_PrintAll(List<Account> accounts, int count)
        {
            Console.WriteLine("저장 개수 : " + count);
            foreach (Account account in accounts)
            {
                account.Print();
            }
        }

        private static void AccountIO_PrintAll(List<AccountIO> accountios, int count)
        {
            Console.WriteLine("저장 개수 : " + count);
            foreach (AccountIO accountio in accountios)
            {
                accountio.Print();
            }
        }
    }
}
