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
    public class AddInfoDal
    {
        public int AddUserInfo(UserInfo userInfo)
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
            int effectedRows = SqlHelper.ExecuteNonQuery(sql, par);
        }
    }
}
