using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ThreeLayer.Model;
using Common;

namespace ThreeLayer.DAL
{
    public class UserInfoDal
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns>返回UserInfo对象list集合</returns>
        public static List<UserInfo> GetUserInfoList()
        {
            string sql = "select * from Course";
            List<UserInfo> list = null;
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text);
                if (dt != null)
                {
                    list = new List<UserInfo>();
                    UserInfo userInfo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        userInfo = new UserInfo();
                        LoadEntity(userInfo, dr);
                        list.Add(userInfo);
                    }
                }
                return list;
            }
            catch { return null; }
        }


        /// <summary>
        /// 执行添加数据的sql语句
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static int AddUserInfo(UserInfo userInfo)
        {
            string sql = "insert into Course([课程名], [课程代码], [任课教师], [学分], [成绩]) values(@课程名, @课程代码, @任课教师, @学分, @成绩)";
            SqlParameter[] par = {
                        new SqlParameter("@课程名",SqlDbType.NVarChar,32),
                        new SqlParameter("@课程代码", SqlDbType.NVarChar, 32),
                        new SqlParameter("@任课教师", SqlDbType.NVarChar, 32),
                        new SqlParameter("@学分", SqlDbType.Int),
                        new SqlParameter("@成绩", SqlDbType.Float)
                    };
            par[0].Value = userInfo.CName;
            par[1].Value = userInfo.CId;
            par[2].Value = userInfo.CTeacher;
            par[3].Value = userInfo.CCredit;
            par[4].Value = userInfo.CGrade;
            try
            {
                int effectedRows = SqlHelper.ExecuteNonQuery(sql, par);
                return effectedRows;
            }
            catch { return 0; }
        }


        /// <summary>
        /// 执行删除语句
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static int DeleteInfo(UserInfo userInfo)
        {
            string sql = "delete from Course where [课程代码] = @课程代码";
            SqlParameter par = new SqlParameter("@课程代码", SqlDbType.NVarChar);
            par.Value = userInfo.CId;
            try
            {
                int deletedRows = SqlHelper.ExecuteNonQuery(sql, par);
                return deletedRows;
            }
            catch { return 0; }
        }


        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="CId"></param>
        /// <returns></returns>
        public static UserInfo GetUserInfoById(string CId)
        {
            string sql = "select * from Course where [课程代码]=@CId";
            SqlParameter par = new SqlParameter("@CId", SqlDbType.NVarChar);
            par.Value = CId;
            UserInfo userInfo = null;
            try
            {
                DataTable dr = SqlHelper.ExecuteDataTable(sql, CommandType.Text, par);
                if (dr != null)
                {
                    userInfo = new UserInfo();
                    LoadEntity(userInfo, dr.Rows[0]);
                }
                return userInfo;
            }
            catch { return null; }
        }


        /// <summary>
        /// 根据主键更新编辑信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static int UpdateUserInfo(UserInfo userInfo)
        {
            string sql = "update Course set [课程名]=@CName, [任课教师]=@CTeacher, [学分]=@CCredit, [成绩]=@CGrade where [课程代码]=@CId";
            SqlParameter[] par = {
                        new SqlParameter("@CName",SqlDbType.NVarChar,32),
                        new SqlParameter("@CId", SqlDbType.NVarChar, 32),
                        new SqlParameter("@CTeacher", SqlDbType.NVarChar, 32),
                        new SqlParameter("@CCredit", SqlDbType.Int),
                        new SqlParameter("@CGrade", SqlDbType.Float)
                    };
            par[0].Value = userInfo.CName;
            par[1].Value = userInfo.CId;
            par[2].Value = userInfo.CTeacher;
            par[3].Value = userInfo.CCredit;
            par[4].Value = userInfo.CGrade;
            try
            {
                int effectedRows = SqlHelper.ExecuteNonQuery(sql, par);
                return effectedRows;
            }
            catch { return 0; }
        }


        /// <summary>
        /// 执行分页存储过程
        /// </summary>
        /// <param name="pageSize">每一页有多少行数据</param>
        /// <param name="pageIndex">当前处于第几页</param>
        /// <returns>返回List集合</returns>
        public static List<UserInfo> GetPageList(int pageSize, int pageIndex)
        {
            string sql = "usp_GetPage";
            SqlParameter[] pars = {
                new SqlParameter("@pageSize",SqlDbType.Int),
                new SqlParameter("@pageIndex",SqlDbType.Int),
                new SqlParameter("@pageTotalCount",SqlDbType.Int)
            };
            //添加存储过程的参数的索引是反的
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Direction = ParameterDirection.Output;
            List<UserInfo> list = null;
            try
            {
                DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.StoredProcedure, pars);
                if (dt != null)
                {
                    list = new List<UserInfo>();
                    UserInfo userInfo = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        userInfo = new UserInfo();
                        LoadEntity(userInfo, dr);
                        list.Add(userInfo);
                    }
                }
                return list;
            }
            catch { return null; }
        }


        public static int GetPageTotalCount()
        {
            string sql = "selcet count(*) from Course";
            return SqlHelper.GetTotalCount(sql);
        }


        /// <summary>
        /// 给字段赋值
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="dr"></param>
        private static void LoadEntity(UserInfo userInfo, DataRow dr)
        {
            userInfo.CName = dr["课程名"] == DBNull.Value ? String.Empty : dr["课程名"].ToString();
            userInfo.CId = dr["课程代码"].ToString();
            userInfo.CTeacher = dr["任课教师"] == DBNull.Value ? String.Empty : dr["任课教师"].ToString();
            userInfo.CCredit = dr["学分"] == DBNull.Value ? 0 : Convert.ToInt32(dr["学分"]);
            userInfo.CGrade = dr["成绩"] == DBNull.Value ? double.NaN : Convert.ToDouble(dr["成绩"]);
        }

    }
}
