//MyMemoryDB.cs
// 메모리DB를 직접 생성하고 사용!
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _0415_데이터베이스
{
    internal class MyMemoryDB
    {
        private DataTable account_table = null;
        public DataTable Account_Table { get { return account_table; } }

        #region 테이블 생성 및 테이블 스키마 출력
        public void Create_AccountTable()
        {
            if (account_table != null)
                account_table.Dispose(); 

            account_table = new DataTable("Account");

            DataColumn col_id           = new DataColumn("id", typeof(int));
            col_id.AutoIncrement        = true;
            col_id.AutoIncrementSeed    = 1000;
            col_id.AutoIncrementStep    = 10;
            account_table.Columns.Add(col_id);

            DataColumn col_name     = new DataColumn("name", typeof(string));
            col_name.AllowDBNull    = false;
            account_table.Columns.Add(col_name);

            DataColumn col_balance      = new DataColumn("balance", typeof(int));
            col_balance.AllowDBNull     = false;
            col_balance.DefaultValue    = 0;
            account_table.Columns.Add(col_balance);

            DataColumn col_date     = new DataColumn("date", typeof(DateTime));
            col_date.AllowDBNull    = false;
            col_date.DefaultValue   = DateTime.Now;
            account_table.Columns.Add(col_date);

            DataColumn[] pkeys = new DataColumn[1];
            pkeys[0] = col_id;
            account_table.PrimaryKey = pkeys;
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
        public void Account_Insert(string name, int balance, DateTime date)
        {
            try
            {
                DataRow r       = account_table.NewRow();
                r["name"]       = name;
                r["balance"]    = balance;
                r["date"]       = date;
                account_table.Rows.Add(r);
                Console.WriteLine("저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Account_Insert(string name, int balance)
        {
            try
            {
                DataRow r       = account_table.NewRow();
                r["name"]       = name;
                r["balance"]    = balance;
                account_table.Rows.Add(r);
                Console.WriteLine("저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Account_Insert(string name)
        {
            try
            {
                DataRow r   = account_table.NewRow();
                r["name"]   = name;
                account_table.Rows.Add(r);
                Console.WriteLine("저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Account_Delete(int id)
        {
            try
            {
                DataRow r = account_table.Rows.Find(id);
                account_table.Rows.Remove(r);
                Console.WriteLine("삭제되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Account_Update_InputMoney(int id, int money)
        {
            try
            {
                DataRow r       = account_table.Rows.Find(id);
                int balance     = int.Parse(r["balance"].ToString());
                balance         = balance + money;
                r["balance"]    = balance;

                Console.WriteLine("삭제되었습니다.");
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
            foreach(DataRow r in account_table.Rows)
            {
                int id          = int.Parse(r["id"].ToString());
                string name     = r["name"].ToString();
                int balance     = int.Parse(r["balance"].ToString());
                DateTime time   = DateTime.Parse(r["date"].ToString());
                accounts.Add(new Account(id, name, balance, time)); 
            }
            return accounts;
        }

        public Account Account_Select(int id)
        {
            try
            {
                DataRow r = account_table.Rows.Find(id);

                string name     = r["name"].ToString();
                int balance     = int.Parse(r["balance"].ToString());
                DateTime time   = DateTime.Parse(r["date"].ToString());
                return new Account(id, name, balance, time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion

        #region XML 파일 사용
        public void Account_Write_Xml()
        {
            account_table.WriteXmlSchema("accounts.xsd", true);
            account_table.WriteXml("accounts.xml");
        }
        public void Account_Read_Xml()
        {
            if (account_table != null)
                account_table.Dispose();

            account_table = new DataTable("Account");
            account_table.ReadXmlSchema("accounts.xsd");
            account_table.ReadXml("accounts.xml");
        }
        #endregion 
    }
}
