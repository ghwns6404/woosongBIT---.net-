//MyDB.cs
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using WoosongBit41.Data;
using _0402_계좌관리프로그램;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Data.OleDb;

namespace _0404_도서관리프로그램_V2
{
    internal class MyDB
    {
        public static MyDB Singleton { get; } = null;
        static MyDB()
        {
            Singleton = new MyDB();
        }   

        private const string server_name = "DESKTOP-6DU0E0H\\SQLEXPRESS";
        private const string db_name = "WB41";
        private const string sql_id = "aaa";
        private const string sql_pw = "1234";

        public SqlConnection scon = null;
        private SqlCommand scmd = null;

        #region 연결
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

        #region  여러줄 출력할때 (Select)
        public List<Customer> SelectAll_cust()
        {
            List<Customer> cust = new List<Customer>();

            string sql = string.Format($"select * from S_Custom;");
            using (SqlCommand cmd = new SqlCommand(sql, scon))
            {
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int cnumber   = int.Parse(r[0].ToString());
                    string cname = r[1].ToString();
                    string cphone = r[2].ToString();       
                    string caddr  = r[3].ToString();


                    Customer b = new Customer()
                    {
                        CNumber = cnumber,
                        Cname = cname,
                        CPhone = cphone,
                        CAddr = caddr
                    };
                    cust.Add(b);
                }
                r.Close();
            } //cmd.Dispose()

            return cust;
        }
        public List<Book> SelectAll_pro()
        {
            List<Book> books = new List<Book>();

            string sql = string.Format($"select * from s_product;");
            using (SqlCommand cmd = new SqlCommand(sql, scon))
            {
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int number = int.Parse(r["PID"].ToString()); //r[0];
                    string pname = r["pname"].ToString();
                    int price = int.Parse(r[2].ToString());
                    string desc = r[3].ToString();

                    Book b = new Book()
                    {
                        Number = number,
                        Name = pname,
                        Price = price,
                        Description = desc
                    };
                    books.Add(b);
                }
                r.Close();
            } //cmd.Dispose()

            return books;
        }
        public Customer SelectCustomer(string cname)
        {
            SqlDataReader r = null;
            try
            {
                Customer b = new Customer();
                string sql = string.Format($"select * from S_Custom where cname = '{cname}';");
                using (SqlCommand cmd = new SqlCommand(sql, scon))
                {
                    r = cmd.ExecuteReader();
                    r.Read();

                    b.CNumber = int.Parse(r[0].ToString()); 
                    b.Cname   = r[1].ToString();     
                    b.CPhone  = r[2].ToString();
                    b.CAddr   = r[3].ToString();                        


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
        public Book SelectBook(string name)
        {
            SqlDataReader r = null;
            try
            {
                Book b = new Book();
                string sql = string.Format($"select * from s_Product where Pname = '{name}';");
                using (SqlCommand cmd = new SqlCommand(sql, scon))
                {
                    r = cmd.ExecuteReader();
                    r.Read();

                    b.Number      = int.Parse(r[0].ToString()); //r[0];
                    b.Name        = r[1].ToString();
                    b.Price       = int.Parse(r[2].ToString());
                    b.Description = r[3].ToString();
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



        //3에서 사용
        public List<Sale> SelectMax()
        {
            List<Sale> sales = new List<Sale>();

            string sql = string.Format($"SELECT TOP 1 p.pname, SUM(s.count) AS total_count FROM s_sale s JOIN s_product p ON s.PID = p.PID GROUP BY p.pname ORDER BY total_count DESC;");
            using (SqlCommand cmd = new SqlCommand(sql, scon))
            {
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    int total_count = int.Parse(r[1].ToString()); 

                    Sale b3 = new Sale()
                    {
                        Total_count = total_count
                    };
                    sales.Add(b3);
                }
                r.Close();
            } //cmd.Dispose()

            return sales;
        }
        public List<SubSale> SelectLog(string cname)
        {
            List<SubSale> subsales = new List<SubSale>();
            SqlDataReader r = null;
            try
            {
                string str = null;
                Customer customer = SelectCustomer(cname);
                int number = customer.CNumber;

                Sale b3 = new Sale();
                string sql = string.Format($"select pname, count, saledate from s_Sale, S_product where cid = {number} and s_product.pid = s_sale.pid;");
                using (SqlCommand cmd = new SqlCommand(sql, scon))
                {
                    r = cmd.ExecuteReader();
                    while(r.Read())
                    {
                        string pname = r["pname"].ToString();
                        int count = int.Parse(r["count"].ToString());
                        string Saledate= r["Saledate"].ToString();

                        SubSale b = new SubSale()
                        {
                            Pname = pname,
                            Count = count,
                            Saledate = Saledate
                        };
                        subsales.Add(b);
                    } 
                } //cmd.Dispose()
                return subsales;
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
        public bool ExSqlCommand(string sql)
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
        public object ExSqlScalarCommand(string sql)
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
