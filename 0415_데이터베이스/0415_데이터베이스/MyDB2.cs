//mydb2.cs
/*
비연결형 데이터베이스
*/ 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _0415_데이터베이스
{
    internal class MyDB2
    {
        private const string server_name    = "DESKTOP-6DU0E0H\\SQLEXPRESS";
        private const string db_name        = "WB41";
        private const string sql_id         = "aaa";
        private const string sql_pw         = "1234";

        private SqlConnection scon              = null;
        private SqlDataAdapter sqlDataAdapter   = new SqlDataAdapter();
        private DataSet db                      = new DataSet("WB41");

        public MyDB2()
        {
            string con = string.Format($"Data Source={server_name};Initial Catalog={db_name};User ID={sql_id};Password={sql_pw}");
            scon = new SqlConnection(con);

            //명령 객체 등록(select, insert, update, delete)
            sqlDataAdapter.InsertCommand = CustomInsert();
            sqlDataAdapter.UpdateCommand = CustomUpdate();
            sqlDataAdapter.DeleteCommand = CustomDelete();

            //Select 명령 등록
            sqlDataAdapter.SelectCommand = CustomSelectAll();            
            sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlDataAdapter.Fill(db, "s_custom");

            sqlDataAdapter.SelectCommand = ProductSelectAll();
            //sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            sqlDataAdapter.Fill(db, "s_product");

            Print_TableSchema(db.Tables["s_custom"]);
            Print_TableSchema(db.Tables["s_product"]);
        }

        #region Update 및 Select에 필요한 Command 등록
        private SqlCommand CustomInsert()
        {
            string sql = "insert into S_Custom values(@Name, @Phone, @Addr);";
            SqlCommand comm = new SqlCommand(sql, scon);
            comm.Parameters.Add("@Name", SqlDbType.VarChar, 50, "cname");
            comm.Parameters.Add("@Phone", SqlDbType.VarChar, 50, "phone");
            comm.Parameters.Add("@Addr", SqlDbType.VarChar, 100, "addr");
            return comm;
        }
        private SqlCommand CustomUpdate()
        {
            string sql = "update S_Custom set phone = @Phone, addr=@Addr where cid = @CId;";
            SqlCommand comm = new SqlCommand(sql, scon);
            comm.Parameters.Add("@Phone", SqlDbType.VarChar, 50, "phone");
            comm.Parameters.Add("@Addr", SqlDbType.VarChar, 100, "addr");
            comm.Parameters.Add("@CId", SqlDbType.Int, 4, "cid");
            return comm;
        }
        private SqlCommand CustomDelete()
        {            
            string sql = "delete from S_Custom where cid = @CId;";
            SqlCommand comm = new SqlCommand(sql, scon);
            comm.Parameters.Add("@CId", SqlDbType.Int, 4, "cid");
            return comm;
        }
        private SqlCommand CustomSelectAll()
        {
            string sql = "select * from s_custom";
            SqlCommand comm = new SqlCommand(sql, scon);
            return comm;
        }
        private SqlCommand ProductSelectAll()
        {
            string sql = "select * from s_product";
            SqlCommand comm = new SqlCommand(sql, scon);
            return comm;
        }
        #endregion

        #region 기능. Select, Insert, Update, Delete : 논리적 DB에서 수행
        public List<string> Custom_SelectAll()
        {
            List<string> list = new List<string>();
            foreach (DataRow row in db.Tables["s_custom"].Rows)
            {
                string str = string.Empty;
                str += row[0] + "#";
                str += row[1] + "#";
                str += row[2] + "#";
                str += row[3];
                list.Add(str);
            }
            return list;
        }
        public void Custom_Insert(string name, string phone, string addr)
        {
            try
            {
                DataRow r   = db.Tables["s_custom"].NewRow();
                r["cname"]  = name;
                r["phone"]  = phone;
                r["addr"]   = addr;
                db.Tables["s_custom"].Rows.Add(r);
                Console.WriteLine("저장 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Custom_Update(int cid, string phone, string addr)
        {
            try
            {
                DataRow r = db.Tables["s_custom"].Rows.Find(cid);                
                r["phone"] = phone;
                r["addr"] = addr;
                Console.WriteLine("수정 되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Custom_Delete(int cid)
        {
            try
            {
                DataRow r = db.Tables["s_custom"].Rows.Find(cid);
                db.Tables["s_custom"].Rows.Remove(r);
                Console.WriteLine("삭제되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region 기능3. update : Update -> 논리적 DB에서 물리적 DB로 복사
        public void MemoryToDataBase()
        {
            sqlDataAdapter.Update(db, "s_custom");
        }
        #endregion

        #region 테이블 스키마 출력 
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
    }
}
