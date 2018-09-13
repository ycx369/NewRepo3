﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary3
{
    public static class DBHelper
    {
        static string strCon = @"Data Source=WACN02601MES\SQLSERVER;Initial Catalog=seee;User ID=sa;Password=dolb123;";
       
        /// <summary>
        /// 使用sql语句实现insert，update，delete功能
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            SqlCommand scmd = new SqlCommand(sql, scon);

            int result = scmd.ExecuteNonQuery();
            scon.Close();
            scon.Dispose();

            return result;

        }

        /// <summary>
        /// 使用存储过程实现insert，update，delete功能
        /// </summary>
        /// <param name="text">存储过程的名字</param>
        /// <param name="parames">存储过程中需要用到的参数数组</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string text, SqlParameter[] parames)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = text;
            scmd.Connection = scon;

            scmd.Parameters.AddRange(parames);

            int result = scmd.ExecuteNonQuery();
            scon.Close();
            scon.Dispose();

            return result;


        }

        /// <summary>
        /// 用sql语句实现断开式查询
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>查询的结果集</returns>

        public static DataSet GetDatasByAdapter(string sql)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            SqlCommand scmd = new SqlCommand(sql, scon);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = scmd;
            sda.Fill(ds);

            scon.Close();
            scon.Dispose();

            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;

        }

        /// <summary>
        /// 用存储过程实现断开式查询
        /// </summary>
        /// <param name="text">存储过程的名字</param>
        /// <param name="parames">存储过程中用到的参数数组</param>
        /// <returns>查询的结果集</returns>
        public static DataSet GetDatasByAdapter(string text, SqlParameter[] parames)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }

            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = text;
            scmd.Connection = scon;
            scmd.Parameters.AddRange(parames);

            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = scmd;
            sda.Fill(ds);

            scon.Close();
            scon.Dispose();

            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 用sql语句实现连接式查询
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>查询的结果集</returns>

        public static SqlDataReader GetDatasByReader(string sql)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            SqlCommand scmd = new SqlCommand(sql, scon);

            SqlDataReader sdr = scmd.ExecuteReader();
            scon.Close();
            scon.Dispose();

            return sdr;

        }

        /// <summary>
        /// 用存储过程实现连接式查询
        /// </summary>
        /// <param name="text">存储过程的名字</param>
        /// <param name="parames">存储过程中用到的参数数组</param>
        /// <returns>查询的结果集</returns>
        public static SqlDataReader GetDatasByReader(string text, SqlParameter[] parames)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }

            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = text;
            scmd.Connection = scon;
            scmd.Parameters.AddRange(parames);

            SqlDataReader sdr = scmd.ExecuteReader();
            scon.Close();
            scon.Dispose();

            return sdr;
        }

        /// <summary>
        /// 用sql语句实现 返回第一行第一列
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(string sql)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            SqlCommand scmd = new SqlCommand(sql, scon);

            object result = scmd.ExecuteScalar();
            scon.Close();
            scon.Dispose();

            return result;

        }

        /// <summary>
        /// 用存储过程实现 返回第一行第一列
        /// </summary>
        /// <param name="text">存储过程的名字</param>
        /// <param name="parames">存储过程的参数数组</param>
        /// <returns>第一行第一列的值</returns>

        public static object ExecuteScalar(string text, SqlParameter[] parames)
        {
            SqlConnection scon = new SqlConnection(strCon);
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            SqlCommand scmd = new SqlCommand();
            scmd.CommandType = CommandType.StoredProcedure;
            scmd.CommandText = text;
            scmd.Connection = scon;

            scmd.Parameters.AddRange(parames);

            object result = scmd.ExecuteScalar();
            scon.Close();
            scon.Dispose();

            return result;

        }
        /// <summary>
        /// 创建数据库连接，对数据库中数据进行查询操作，返回查询到的结果集
        /// </summary>
        /// <param name="text">存储过程的名字</param>
        /// <param name="prame">存储过程的参数数组</param>
        /// <returns>返回查询到的所有结果</returns>
        public static DataSet ExecuteSec(string text, SqlParameter[] prame)
        {
            SqlConnection scon = new SqlConnection(strCon);//创建数据库连接对象
            if (scon.State != ConnectionState.Open)//判断并打开数据库连接
                scon.Open();
            SqlCommand scmd = new SqlCommand();//创建数据库命令对象
            scmd.Connection = scon;//指定连接
            scmd.CommandType = CommandType.StoredProcedure;//指定要执行的命令的类型
            scmd.CommandText = text;//指定存储过程
            if (prame != null)
            {
                scmd.Parameters.AddRange(prame);//将存储过程的参数传递给存储过程            
            }


            DataSet ds = new DataSet();//创建结果集对象
            SqlDataAdapter sda = new SqlDataAdapter();//创建数据库适配器对象
            sda.SelectCommand = scmd;//指定适配器对象的命令
            sda.Fill(ds);//将适配器对象获取到的结果存储在结果集对象当中

            scon.Close();//关闭数据库连接
            scon.Dispose();//销毁数据库连接对象
            scmd.Dispose();//销毁数据库命令对象

            if (ds.Tables.Count > 0 && ds != null)//判断获取到的结果集是否为空，如果不为空，则返回查询结果，如果为空，返回null
            {
                return ds;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExcuteSqlreturnInt(string sql)
        {
            //创建连接对象
            SqlConnection conn = new SqlConnection(strCon);
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
    }
}
