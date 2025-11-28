//MyDB1.cs
//StoredProcedure 활용한 DB 사용
using System;
using System.Data.SqlClient;

namespace _0415_데이터베이스
{
    internal class MyDB1
    {
        private const string server_name = "DESKTOP-0I86BTV\\SQLEXPRESS";
        private const string db_name = "wb41";
        private const string sql_id = "aaa";
        private const string sql_pw = "1234";

        private SqlConnection scon = null;        

        #region 연결, 종료
        public bool Connect()
        {
            try
            {
                string con = string.Format($"Data Source={server_name};Initial Catalog={db_name};User ID={sql_id};Password={sql_pw}");
                scon = new SqlConnection(con);
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

        #region DB 명령 함수(ExecuteNonQuery:I,U,D),(ExcecuteScalar:S),(ExcecuteReader:S)
        private bool ExSqlCommand(SqlCommand cmd)
        {
            try
            {
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("[예외] " + ex.Message);
                return false;
            }
        }
        /*
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
        */
        #endregion

        #region 프로시저 사용코드
        public void AddProduct(string pname, int price, string description)
        {
            string comtext = "AddProduct";

            SqlCommand cmd = new SqlCommand(comtext, scon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param_pname = new SqlParameter("@PNAME", pname);
            cmd.Parameters.Add(param_pname);

            SqlParameter param_price = new SqlParameter("@Price", price);
            param_price.SqlDbType = System.Data.SqlDbType.Int;
            cmd.Parameters.Add(param_price);

            SqlParameter param_description = new SqlParameter("@Description", pname);
            cmd.Parameters.Add(param_description);

            if (ExSqlCommand(cmd) == true)
                Console.WriteLine("성공");
            else
                Console.WriteLine("실패");

            cmd.Dispose();
        }

        public void FindCIDByName(string cname)
        {
            string comtext = "FindCIDByName";

            SqlCommand cmd = new SqlCommand(comtext, scon);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param_cname = new SqlParameter("@CName", cname);
            cmd.Parameters.Add(param_cname);

            SqlParameter param_cid = new SqlParameter();
            param_cid.ParameterName = "@CID";
            param_cid.SqlDbType     = System.Data.SqlDbType.Int;
            param_cid.Direction     = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(param_cid);

            if (ExSqlCommand(cmd) == true)
            {
                Console.WriteLine("성공");
                int cid = (int)param_cid.Value;
                Console.WriteLine(cname + " -> " + cid);
            }
            else
                Console.WriteLine("실패");
        }

        #endregion 
    }
}
