using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibrary3
{
   public class sqlhelper
    {
        public string Sqlconnstring
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DB"].ConnectionString.ToString();
            }
        }
        public DataSet SelectMysqlreturnDataset(string mysql)
        {
            SqlConnection conn = new SqlConnection(Sqlconnstring);
            SqlDataAdapter sda = new SqlDataAdapter(mysql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
        public int ExcuteSqlreturnInt(string sql, SqlParameter[] pars, CommandType type)
        {
            //创建连接对象
            SqlConnection conn = new SqlConnection(Sqlconnstring);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Connection = conn;
                //cmd.CommandText = sql;
                //打开连接对象
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                if (pars != null && pars.Length > 0)
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);
                    }
                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);   //后加
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public int ExcuteSqlreturnInt(string sql)
        {
            //创建连接对象
            SqlConnection conn = new SqlConnection(Sqlconnstring);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Connection = conn;
                //cmd.CommandText = sql;
                //打开连接对象
                if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    conn.Open();
                }
                //if (pars != null && pars.Length > 0)
                //    foreach (SqlParameter p in pars)
                //    {
                //        cmd.Parameters.Add(p);
                //    }
                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);   //后加
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public SqlDataReader SelectSqlReturnDatareader(string sql)
        {
            SqlConnection conn = new SqlConnection(Sqlconnstring);
            SqlCommand cmd = new SqlCommand(Sqlconnstring, conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader reader = cmd.ExecuteReader (CommandBehavior.CloseConnection);
            return reader;
        }
        public  object ExecuteScalar(string sqlText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(Sqlconnstring)) 
            {

                using (SqlCommand cmd = conn.CreateCommand())
                {

                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        //public static SqlDataReader GetReader(string sql)
        //{
        //    SqlConnection conn = new SqlConnection(sqlhelper.Sqlconnstring);
        //    using (SqlCommand cmd = new SqlCommand(Sqlconnstring, conn))
        //    {
        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        return reader;
        //    }
        //}
    }
}
