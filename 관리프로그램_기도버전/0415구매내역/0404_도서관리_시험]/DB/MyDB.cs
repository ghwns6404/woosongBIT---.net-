//MyDB.cs
using System;
using WoosongBit41.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WoosongBit41.DB
{
	internal class MyDB
	{
		private const string server_name = "DESKTOP-6DU0E0H\\SQLEXPRESS"; 
		private const string db_name = "WB41";
		private const string sql_id = "aaa";
		private const string sql_pw = "1234";

		private SqlConnection scon = null;
		private SqlCommand scmd = null;
		#region 연결, 종료
		public bool Connect()
		{
			try
			{
				string con = string.Format($"Data Source={server_name};Initial Catalog={db_name};User ID={sql_id};Password={sql_pw};");
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
		public bool Insert_Sale(string cname, string pname, int count)
		{
			string sql = string.Format($"INSERT INTO s_sale VALUES((select cid from s_custom where cname = '{cname}'),(select pid from S_Product where pname = '{pname}'),{count}, GETDATE());");
			return ExSqlCommand(sql);
		}
		public bool Update_Book1(int pid, int price)
		{
			string sql = string.Format($"update s_product set price = {price} where pid = {pid};");
			return ExSqlCommand(sql);
		}
		public bool Update_Book2(string name, int price)
		{
			string sql = string.Format($"update s_product set price = {price} where pname = '{name}';");
			return ExSqlCommand(sql);
		}
		public bool Delete_Book(string cname, string pname)
		{
			string sql = string.Format($"delete from S_Sale where CID = (select CID from S_Custom where cname = '{cname}') and PID = (select PID from s_product where pname ='{pname}');");
			return ExSqlCommand(sql);
		}
		#endregion

		#region 하나의 값을 반환하는 Select
		public Sale SelectSale(int SID)
		{
			Sale sale = new Sale();
			string sql = string.Format($"select * from S_Sale where SID = {SID};");
			using (SqlCommand cmd = new SqlCommand(sql, scon))
			{
				SqlDataReader r = cmd.ExecuteReader();
				r.Read();
                sale.Sid = int.Parse(r["SID"].ToString());
                sale.Cid = int.Parse(r["CID"].ToString());
				sale.Pid = int.Parse(r["PID"].ToString());
				sale.Count = int.Parse(r["COUNT"].ToString());
				sale.Date = DateTime.Parse(r["SaleDate"].ToString());
				r.Close();
			} //cmd.Dispose()

			return sale;
		}
		public void Update_Sale(string member_name, string book_name, int count)
		{
			try
			{
				string sql = string.Format($"update s_Sale set s_sale.count = {count} where cid =(select cid from S_CUstom where cname ='{member_name}')AND pid =(select pid from S_Product where pname ='{book_name}');");
				ExSqlCommand(sql);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#region 다중로우 데이터를 반환하는 Select

		public void SelectNameSale(int SID, out string pname, out string cname)
        {
            pname = string.Empty;
            cname = string.Empty;
            string sql = string.Format($"select cname, pname from S_Custom, S_Product where (PID) = (select PID from S_Sale where SID = {SID}) and cid = (select cid from S_Sale where SID = {SID});");

            using (SqlCommand cmd = new SqlCommand(sql, scon))
            {
                SqlDataReader r = cmd.ExecuteReader();
				r.Read();
                
				pname = r["pname"].ToString();
                cname = r["cname"].ToString();
                
                r.Close();
            } //cmd.Dispose()
        }	

        public List<Sale> SelectAllSale()
		{
			List<Sale> Sales = new List<Sale>();
			string sql = string.Format($"select * from S_Sale;");
			using (SqlCommand cmd = new SqlCommand(sql, scon))
			{
				SqlDataReader r = cmd.ExecuteReader();
				while (r.Read())
				{
					Sale sale = new Sale()
					{
                        Sid = int.Parse(r["SID"].ToString()),
                        Cid = int.Parse(r["CID"].ToString()),
						Pid = int.Parse(r["PID"].ToString()),
						Count = int.Parse(r["COUNT"].ToString()),
						Date = DateTime.Parse(r["SaleDate"].ToString())
					};
					Sales.Add(sale);
				}
				r.Close();
			} //cmd.Dispose()

			return Sales;
		}
		public List<Book> SelectAllBook()
		{
			List<Book> books = new List<Book>();

			string sql = string.Format($"select * from S_Product;");
			using (SqlCommand cmd = new SqlCommand(sql, scon))
			{
				SqlDataReader r = cmd.ExecuteReader();
				while (r.Read())
				{
					Book book = new Book()
					{
						Number = int.Parse(r["PID"].ToString()),
						Name = r["PNAME"].ToString(),
						Price = int.Parse(r["PRICE"].ToString()),
						Description = r["Description"].ToString()
					};
					books.Add(book);
				}
				r.Close();
			} //cmd.Dispose()

			return books;
		}
		public List<Member> SelectAllMember()
		{
			List<Member> members = new List<Member>();

			string sql = string.Format($"select * from S_Custom;");
			using (SqlCommand cmd = new SqlCommand(sql, scon))
			{
				SqlDataReader r = cmd.ExecuteReader();
				while (r.Read())
				{
					Member member = new Member()
					{
						Number = int.Parse(r["CID"].ToString()),
						Name = r["cNAME"].ToString(),
						Phone = r["Phone"].ToString(),
						Addr = r["Addr"].ToString()
					};
					members.Add(member);
				}
				r.Close();
			} //cmd.Dispose()

			return members;
		}
		public Book SelectBook(int pid)
		{
			SqlDataReader r = null;

			try
			{
				Book b = new Book();
				string sql = string.Format($"select pname, price,description from s_product where pid = {pid};");
				using (SqlCommand cmd = new SqlCommand(sql, scon))
				{
					r = cmd.ExecuteReader();
					r.Read();


					b.Name = r["pname"].ToString();
					b.Price = int.Parse(r[1].ToString());
					b.Description = r[2].ToString();


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
		public Member SelectMember(int cid)
		{
			SqlDataReader r = null;

			try
			{
				Member b = new Member();
				string sql = string.Format($"select cname, phone, addr from s_custom where cid = {cid};");
				using (SqlCommand cmd = new SqlCommand(sql, scon))
				{
					r = cmd.ExecuteReader();
					r.Read();

					Member member = new Member()
					{
						Number = int.Parse(r["CID"].ToString()),
						Name = r["cNAME"].ToString(),
						Phone = r["Phone"].ToString(),
						Addr = r["Addr"].ToString()
					};

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

		#endregion

		#region DB 명령 함수
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
		#endregion
	}
}
