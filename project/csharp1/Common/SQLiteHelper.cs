using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SQLite;
using System.Data;

namespace Common
{
    public class SQLiteHelper
    {
        //从app.config中获取连接字符串
        public static readonly string conStr = ConfigurationManager.ConnectionStrings["conStrSQLite"].ConnectionString;

        /// <summary>
        /// 执行查询
        /// 从外部调用SQliteDataReader.Close()关闭SQLiteConnection连接
        /// </summary>
        /// <param name="sql">SQLite语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回SQLiteDataReader对象</returns>
        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] param)
        {
            SQLiteDataReader reader = null;
            SQLiteConnection con = new SQLiteConnection(conStr);
            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
            {
                if (param != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(param);
                }
                try
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    return reader;
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// 执行查询，返回一张表
        /// </summary>
        /// <param name="sql">SQLite语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ExecuteDataTable(string sql, params SQLiteParameter[] param) 
        {
            DataTable dt = null;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, con);
                if (param != null)
                {
                    adapter.SelectCommand.Parameters.Clear();
                    adapter.SelectCommand.Parameters.AddRange(param);
                }
                adapter.Fill(dt);
            }
            return dt;
        }


        /// <summary>
        /// 增删查函数
        /// </summary>
        /// <param name="sql">SQLite语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] param)
        {
            int rowsAffected = 1;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (param != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(param);
                    }
                    try
                    {
                        con.Open();
                        rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 查询首行首列
        /// </summary>
        /// <param name="sql">SQLite语句</param>
        /// <param name="param">参数数组</param>
        /// <returns>返回object首行数据</returns>
        public static object ExecuteScalar(string sql, params SQLiteParameter[] param)
        {
            object scalarResult = null;
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (param != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(param);
                    }
                    try
                    {
                        con.Open();
                        scalarResult = cmd.ExecuteScalar();
                        return scalarResult;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }



        //构建参数示例
        //SQLiteParameter[] pms = new SQLiteParameter[]
        //{
        //        new SQLiteParameter("@loginId",SqlDbType.VarChar,50){ Value =loginId},
        //        new SQLiteParameter("@pwd",SqlDbType.VarChar,50){ Value =password},
        //};
    }
}
