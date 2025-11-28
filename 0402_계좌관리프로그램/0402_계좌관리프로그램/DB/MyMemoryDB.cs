//MyMemoryDB.cs
using System;
using System.Collections.Generic;
using System.Data;
using WoosongBit41.Data;
using System.IO;

namespace _0402_계좌관리프로그램
{

    internal class MyMemoryDB
    {
       
        private DataTable account_table = null;
        public DataTable Account_Table { get { return account_table; } }

        private DataTable accountio_table = null;
        public DataTable AccountIO_Table { get { return accountio_table; } }

        #region 테이블 생성 및 테이블 스키마 출력
        public void Create_AccountTable()
        {
            if (account_table != null)
                account_table.Dispose();

            account_table = new DataTable("Account");

            DataColumn col_number = new DataColumn("number", typeof(int));
            col_number.AutoIncrement = true;
            col_number.AutoIncrementSeed = 1000;
            col_number.AutoIncrementStep = 10;
            account_table.Columns.Add(col_number);

            DataColumn col_name = new DataColumn("name", typeof(string));
            col_name.AllowDBNull = false;
            account_table.Columns.Add(col_name);

            DataColumn col_balance = new DataColumn("balance", typeof(int));
            col_balance.AllowDBNull = false;
            col_balance.DefaultValue = 0;
            account_table.Columns.Add(col_balance);

            DataColumn col_date = new DataColumn("date", typeof(DateTime));
            col_date.AllowDBNull = false;
            col_date.DefaultValue = DateTime.Now;
            account_table.Columns.Add(col_date);

            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = col_number;
            account_table.PrimaryKey = pkeys;
        }
        public void Create_accountio_table()
        {
            if (accountio_table != null)
                accountio_table.Dispose();

            accountio_table = new DataTable("AccountIO");

            DataColumn col_number = new DataColumn("number", typeof(int));
            col_number.AutoIncrement = true;
            col_number.AutoIncrementSeed = 1000;
            col_number.AutoIncrementStep = 10;
            accountio_table.Columns.Add(col_number);

            DataColumn col_input = new DataColumn("input", typeof(int));
            col_input.AllowDBNull = false;
            accountio_table.Columns.Add(col_input);

            DataColumn col_output = new DataColumn("output", typeof(int));
            col_output.AllowDBNull = false;
            accountio_table.Columns.Add(col_output);

            DataColumn col_balance = new DataColumn("balance", typeof(int));
            col_balance.AllowDBNull = false;
            col_balance.DefaultValue = 0;
            accountio_table.Columns.Add(col_balance);

            DataColumn col_date = new DataColumn("date", typeof(DateTime));
            col_date.AllowDBNull = false;
            col_date.DefaultValue = DateTime.Now;
            accountio_table.Columns.Add(col_date);

            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = col_number;
            accountio_table.PrimaryKey = pkeys;
        }

        public void Print_TableSchema(DataTable dt)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"[테이블 명] {dt.TableName}");
            Console.WriteLine($"[컬럼 개수] {dt.Columns.Count}");
            Console.WriteLine($"[로우 데이터 개수] {dt.Rows.Count}");
            Console.WriteLine($"[기본키(PK)] {dt.PrimaryKey[0]}");
            Console.WriteLine("---------------------------------------------------");
            foreach (DataColumn col in dt.Columns)
            {
                Console.WriteLine($"{col.ColumnName} \t {col.DataType} \t " +
                    $"{col.AllowDBNull} \t {col.DefaultValue} \t {col.AutoIncrement}");
            }
            Console.WriteLine("---------------------------------------------------");
        }
        #endregion

        #region Account Table : Insert, Update, Delete
        public int Account_Insert(string name, int balance)
        {
            try
            {
                DataRow r = account_table.NewRow();
                r["name"] = name;
                r["balance"] = balance;
                account_table.Rows.Add(r);
                Console.WriteLine("저장 성공");

                DataColumn col = account_table.Columns["number"];
                int id = int.Parse(r[col].ToString());
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }
        public void AccountIO_Insert(int input, int output, int balance)
        {
            try
            
            {
                DataRow r1 = accountio_table.NewRow();

                //r1["id"] = id;
                r1["input"] = input;
                r1["output"] = output;
                r1["balance"] = balance;
                accountio_table.Rows.Add(r1);

                Console.WriteLine("저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Account_Delete(int number)
        {
            try
            {
                DataRow r = account_table.Rows.Find(number);
                account_table.Rows.Remove(r);
                Console.WriteLine("삭제되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Account_Update_InputMoney(int number, int money)
        {
            try
            {
                DataRow r = account_table.Rows.Find(number);
                DataRow r1 = accountio_table.Rows.Find(number);
                int balance = int.Parse(r["balance"].ToString());
                balance = balance + money;
                r["balance"] = balance;

                Console.WriteLine("입금 되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Account_Update_OutputMoney(int number, int money)
        {
            try
            {
                DataRow r = account_table.Rows.Find(number);
                DataRow r1 = accountio_table.Rows.Find(number);
                int balance = int.Parse(r["balance"].ToString());
                balance = balance - money;
                r["balance"] = balance;

                Console.WriteLine("출금 되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region Account Table Select 관련 기능
        public List<Account> Account_SelectAll()
        {

            List<Account> accounts = new List<Account>(); 
            foreach (DataRow r in account_table.Rows)
            {
                int number = int.Parse(r["number"].ToString());
                string name = r["name"].ToString();
                int balance = int.Parse(r["balance"].ToString());
                DateTime time = DateTime.Parse(r["date"].ToString());
                accounts.Add(new Account(number, name, balance, time));
            }
            return accounts;
        }

        public Account Account_Select(int number)
        {
            try
            {
                DataRow r = account_table.Rows.Find(number);

                string name = r["name"].ToString();
                int balance = int.Parse(r["balance"].ToString());
                DateTime time = DateTime.Parse(r["date"].ToString());
                return new Account(number, name, balance, time);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region XML 파일 사용
        
        public bool Account_Write_Xml()
        {
            account_table.WriteXmlSchema("accounts.xsd", true);
            account_table.WriteXml("accounts.xml");
            return true;
        }
        public bool AccountIO_Write_Xml()
        {
            accountio_table.WriteXmlSchema("accountIOs.xsd", true);
            accountio_table.WriteXml("accountIOs.xml");
            return true;
        }


        public void Account_Read_Xml()
        {
            try
            {
                if (account_table != null)
                    account_table.Dispose();

                account_table = new DataTable("Account");
                account_table.ReadXmlSchema("accounts.xsd");
                account_table.ReadXml("accounts.xml");
            }
            catch 
            {
                Create_AccountTable(); 
            }
        }
        public void AccountIO_Read_Xml()
        {
            try
            {
                if (accountio_table != null)
                    accountio_table.Dispose();

                accountio_table = new DataTable("AccountIO");
                accountio_table.ReadXmlSchema("accountIOs.xsd");
                accountio_table.ReadXml("accountIOs.xml");
            }
            catch
            {
                Create_accountio_table();
            } 
        }
        #endregion 
    }
}
