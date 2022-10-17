using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SqlHelper
    {
        public static readonly string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 1、静态SqlDataAdapter查询函数:
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="type">指定sql语句类型</param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, CommandType type, params SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.SelectCommand.CommandType = type;
                adapter.SelectCommand.Parameters.Clear();
                adapter.SelectCommand.Parameters.AddRange(param);
                adapter.Fill(dt);
            }
            return dt;
        }


        /// <summary>
        /// 2、静态增删改函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] param)
        {
            int n = -1;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(param);
                    n = cmd.ExecuteNonQuery();
                }
            }
            return n;
        }


        /// <summary>
        /// 3、执行查询，返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] param)
        {
            object o = null;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(param);
                    o = cmd.ExecuteScalar();
                }
            }
            return o;
        }


        /// <summary>
        /// 4、DataReader
        /// 需要手动在外部关闭SqlDataReader对象
        /// 一行一行地读取，在读取的过程中一直和数据库保持连接
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] param)
        {
            SqlDataReader reader;
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(param);
                //在外部关闭SqlDataReader对象,CommandBehavior.CloseConnection：如果关闭SqlDataReader,则con随之关闭
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return reader;
        }


        /// <summary>
        /// 查询总行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int GetTotalCount(string sql, params SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(param);
                    try
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch { return 0; }
                }
            }
        }
    }
}
