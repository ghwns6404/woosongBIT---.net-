using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoosongBit41.Data;
using WoosongBit41.Lib;

namespace _0402_계좌관리프로그램
{
    internal class SelectNameAll
    {
        public void Invoke() //p134
        {
            Console.WriteLine("\n[계좌 전체 출력(이름기반)]\n");

            string name = WbLib.InputString("이름 입력");
            AccountControl con = AccountControl.Singleton;
            List<Account> accounts = con.SelectAllName(name);
            Print(accounts);
        }

        private void Print(List<Account> accounts)
        {
            foreach(Account account in accounts) {
                account.Print();
            }
        }
    }
}
