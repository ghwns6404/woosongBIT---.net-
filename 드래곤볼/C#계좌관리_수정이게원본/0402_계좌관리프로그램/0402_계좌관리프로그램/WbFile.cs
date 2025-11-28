//WbFile.cs
using System;
using WoosongBit41.Lib;
using WoosongBit41.Data;
using System.IO;

namespace WoosongBit41.File
{
    internal static class WbFile
    {
        private const string ACCOUNTS_FILENAME      = "accounts.txt";
        private const string ACCOUNTIOS_FILENAME    = "accountios.txt";

        //text모드(데이터 기반)
        public static void Write_Accounts(WbArray accounts)
        {
            StreamWriter writer = new StreamWriter(ACCOUNTS_FILENAME);
            writer.WriteLine(accounts.Arr.Count);
            for (int i = 0; i < accounts.Arr.Count; i++)
            {
                Account account = (Account)accounts[i];
                string temp = string.Empty;
                temp += account.Number + "@";
                temp += account.Name + "@";
                temp += account.Balance + "@";
                temp += account.Ctime;
                writer.WriteLine(temp);
            }
            writer.Dispose();  
        }
        public static void Write_Accountios(WbArray accountios)
        {
            StreamWriter writer = new StreamWriter(ACCOUNTIOS_FILENAME);
            writer.WriteLine(accountios.Arr.Count);
            for (int i = 0; i < accountios.Arr.Count; i++)
            {
                AccountIO accountio = (AccountIO)accountios[i];
                string temp = string.Empty;
                temp += accountio.Number    + "@";
                temp += accountio.Input     + "@";
                temp += accountio.Output    + "@";
                temp += accountio.Balance   + "@";
                temp += accountio.CTime;
                writer.WriteLine(temp);
            }
            writer.Dispose();
        }
        public static void Read_Accounts(WbArray accounts)
        {
            StreamReader reader = new StreamReader(ACCOUNTS_FILENAME);
            int size = int.Parse(reader.ReadLine());
            for (int i = 0; i < size; i++)
            {
                string temp     = reader.ReadLine();  //번호@이름@잔액@날짜
                string[] sp     = temp.Split('@');
                int number      = int.Parse(sp[0]);
                string name     = sp[1];
                int balance     = int.Parse(sp[2]);
                DateTime ctime  = DateTime.Parse(sp[3]);

                accounts.Add(new Account(number, name, balance, ctime));
            }
            reader.Dispose();
        }
        public static void Read_Accountios(WbArray accountios)
        {
            StreamReader reader = new StreamReader(ACCOUNTIOS_FILENAME);
            int size = int.Parse(reader.ReadLine());
            for (int i = 0; i < size; i++)
            {
                string temp = reader.ReadLine();  //번호@이름@잔액@날짜
                string[] sp = temp.Split('@');
                int number      = int.Parse(sp[0]);
                int input       = int.Parse(sp[1]);
                int output      = int.Parse(sp[2]);
                int balance     = int.Parse(sp[3]);
                DateTime ctime  = DateTime.Parse(sp[4]);

                accountios.Add(new AccountIO(number, input, output, balance, ctime));
            }
            reader.Dispose();
        }
    }
}
