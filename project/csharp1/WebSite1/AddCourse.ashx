<%@ WebHandler Language="C#" Class="AddUserInfo" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Configuration;

public class AddUserInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //接收post请求发送出的数据
        string courseName = context.Request.Form["txtName"];
        string courseId = context.Request.Form["txtId"];
        string courseTeacher = context.Request.Form["txtTeacher"];
        string courseCredit = context.Request.Form["txtCredit"];
        int credit;
        bool b = int.TryParse(courseCredit, out credit);
        string courseGrade = context.Request.Form["txtGrade"];
        float grade;
        b = float.TryParse(courseGrade, out grade);
        if (b == false)
        {
            //当转换失败时不继续执行
            context.Response.Write("参数错误！");
            return;
        }
        //连接字符串
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        //拼写sql语句
        string sql = "insert into Course([课程名], [课程代码], [任课教师], [学分], [成绩]) values(@课程名, @课程代码, @任课教师, @学分, @成绩)";
        //数据库连接操作
        using (SqlConnection con = new SqlConnection(conStr))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                //添加参数
                SqlParameter[] par = {
                        new SqlParameter("@课程名",SqlDbType.NVarChar,32),
                        new SqlParameter("@课程代码", SqlDbType.NVarChar, 32),
                        new SqlParameter("@任课教师", SqlDbType.NVarChar, 32),
                        new SqlParameter("@学分", SqlDbType.Int),
                        new SqlParameter("@成绩", SqlDbType.Float)
                    };
                par[0].Value = courseName;
                par[1].Value = courseId;
                par[2].Value = courseTeacher;
                par[3].Value = credit;
                par[4].Value = grade;
                cmd.Parameters.AddRange(par);
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        //实现页面跳转(重定位)
                        //同时向跳转的页面发送了get请求
                        context.Response.Redirect("QueryAll.ashx", false);
                        //在使用Redirect方法的时候，第二个参数传递false表示取消对 Response.End 的内部调用
                    }
                }
                catch
                {
                    context.Response.Write("插入失败！");
                }
            }
        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}