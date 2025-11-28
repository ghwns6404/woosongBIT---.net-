//MyDB.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _0415_데이터베이스
{
    internal class MyDB
    {
        private const string server_name = "DESKTOP-0I86BTV\\SQLEXPRESS";
        private const string db_name = "wb41";
        private const string sql_id = "aaa";
        private const string sql_pw = "1234";

        private SqlConnection scon = null;
        private SqlCommand    scmd = null;

        #region 연결, 종료
        public bool Connect()
        {
            try
            {
                string con = string.Format($"Data Source={server_name};Initial Catalog={db_name};User ID={sql_id};Password={sql_pw}");
                scon = new SqlConnection(con);
                scmd = scon.CreateCommand();
                scon.Open();               
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Close()
        {
            try
            {
                scon.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        #endregion

        #region Insert, Update, Delete Test
        //INSERT INTO s_product VALUES('C# Network', 20000, 'C# Network 설명...');
        public bool Insert_Book(string name, int price, string description)
        {
            string sql = string.Format($"INSERT INTO s_product VALUES('{name}', {price}, '{description}')");
            return ExSqlCommand(sql);
        }
        //update s_product set price = 25000 where pid = 1010;
        public bool Update_Book1(int pid, int price)
        {
            string sql = string.Format($"update s_product set price = {price} where pid = {pid};");
            return ExSqlCommand(sql);
        }
        //update s_product set price = 25000 where pname = 'C언어';
        public bool update_Book2(string name, int price)
        {
            string sql = string.Format($"update s_product set price = {price} where pname = '{name}';");
            return ExSqlCommand(sql);
        }
        //delete from s_product where pid=20000;
        public bool Delete_Book1(int pid)
        {
            string sql = string.Format($"delete from s_product where pid={pid};");
            return ExSqlCommand(sql);
        }
        //delete from s_product where pname='C#';
        public bool Delete_Book2(string name)
        {
            string sql = string.Format($"delete from s_product where pname='{name}';");
            return ExSqlCommand(sql);
        }
        #endregion

        #region 하나의 값을 반환하는 Select
        //select SUM(Price) from s_product;
        public int Get_TotalPrice()
        {
            string sql = string.Format($"select SUM(Price) from s_product;");
            object obj = ExSqlScalarCommand(sql);
            if (obj == null)
                throw new Exception("오류 발생");
            return (int)obj;                
        }
        //select MAX(Price) from s_product;
        public int Get_MaxPrice()
        {
            string sql = string.Format($"select MAX(Price) from s_product;");
            object obj = ExSqlScalarCommand(sql);
            if (obj == null)
                throw new Exception("오류 발생");
            return (int)obj;
        }
        #endregion

        #region  다중로우 데이터를 반환하는 Select
        //select * from s_product;
        public List<Book> SelectAll()
        {
            List<Book> books = new List<Book>();

            string sql = string.Format($"select * from s_product;");
            using (SqlCommand cmd = new SqlCommand(sql, scon))
            {
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int number   = int.Parse(r["PID"].ToString()); //r[0];
                    string pname = r["pname"].ToString();
                    int price    = int.Parse(r[2].ToString());
                    string desc  = r[3].ToString();

                    Book b = new Book()
                    {
                        Number      = number,
                        Name        = pname,
                        Price       = price,
                        Description = desc
                    };
                    books.Add(b);
                }
                r.Close();
            } //cmd.Dispose()
             
            return books;
        }
        //select PNAME, PRICE from s_Product where pid = 1020;
        public Book SelectBook(int pid)
        {
            SqlDataReader r = null;
            try
            {
                Book b = new Book();
                string sql = string.Format($"select PNAME, PRICE from s_Product where pid = {pid};");
                using (SqlCommand cmd = new SqlCommand(sql, scon))
                {
                    r = cmd.ExecuteReader();
                    r.Read();

                    b.Name = r["pname"].ToString();
                    b.Price = int.Parse(r[1].ToString());
                } //cmd.Dispose()
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                r.Close();
            }
        }
        #endregion

        #region DB 명령 함수(ExecuteNonQuery:I,U,D),(ExcecuteScalar:S),(ExcecuteReader:S)
        private bool ExSqlCommand(string sql)
        {
            try
            {
                scmd.Connection = scon;
                scmd.CommandText = sql;

                if (scmd.ExecuteNonQuery() == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private object ExSqlScalarCommand(string sql)
        {
            try
            {
                scmd.Connection = scon;
                scmd.CommandText = sql;

                return scmd.ExecuteScalar();          
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
                
        #endregion 
    }
}
