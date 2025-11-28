using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class PrintAllAccount
    {
        public void Invoke() //p134
        {
            Console.WriteLine("\n[계좌 전체 출력]\n");

            try
            {  
                AccountControl con      = AccountControl.Singleton;
                Console.WriteLine("--------------------------------------------");
                Account_PrintAll(con.Accounts, con.Accounts_Count);
                Console.WriteLine("--------------------------------------------");
                AccountIO_PrintAll(con.Accountios, con.Accountios.Count);
                Console.WriteLine("--------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    
        private void Account_PrintAll(List<Account> accounts, int count)
        {
            Console.WriteLine("저장 개수 : " + count);
            foreach (Account account in accounts)
            {
                account.Print();
            }
        }

        private void AccountIO_PrintAll(List<AccountIO> accountios, int count)
        {
            Console.WriteLine("저장 개수 : " + count);
            foreach (AccountIO accountio in accountios)
            {
                accountio.Print();
            }
        }
    }
}
