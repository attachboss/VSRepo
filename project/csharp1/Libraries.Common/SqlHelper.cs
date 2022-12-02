using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.Common
{
    public class SqlHelper
    {
        public static string conStr = "Data Source=.;Initial Catalog = Student; Integrated Security = True";

        /// <summary>
        /// 1、静态SqlDataAdapter查询函数:
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
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
                    if (param != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(param);
                    }
                    try
                    {
                        con.Open();
                        n = cmd.ExecuteNonQuery();
                        return n;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
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
                    if (param != null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddRange(param);
                    }
                    try
                    {
                        con.Open();
                        o = cmd.ExecuteScalar();
                        return o;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// 4、DataReader
        /// 需要手动在外部关闭SqlDataReader对象
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
                if (param != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(param);
                }
                try
                {
                    con.Open();
                    //在外部关闭SqlDataReader对象,CommandBehavior.CloseConnection：如果关闭SqlDataReader,则con随之关闭
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return reader;

                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        //构建参数示例
        //SqlParameter[] pms = new SqlParameter[]
        //{
        //        new SqlParameter("@loginId",SqlDbType.VarChar,50){ Value =loginId},
        //        new SqlParameter("@pwd",SqlDbType.VarChar,50){ Value =password},
        //};
    }
}
