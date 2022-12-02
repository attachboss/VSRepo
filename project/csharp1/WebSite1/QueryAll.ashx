<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class Handler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //获取文件的绝对路径
        string filePath = context.Request.MapPath("HtmlPage.html");
        //读取文件的内容
        string fileContent = File.ReadAllText(filePath);
        //连接数据库
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        string sql = "select * from Course";
        using (SqlConnection con = new SqlConnection(conStr))
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                adapter.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow row in dt.Rows)
                    {
                        //以课程代码为主键
                        sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a class='deleteCourse' href='DeleteCourse.ashx?课程代码={1}'>删除</a></td></tr>", row["课程名"].ToString(), row["课程代码"].ToString(), row["任课教师"].ToString(), row["学分"].ToString(),row["成绩"].ToString());
                    }
                    fileContent = fileContent.Replace("@tbody", sb.ToString());
                }
            }
            catch
            {
                context.Response.Write("查询失败！");
            }
        }














        //获取表单中的数值
        //int num = Convert.ToInt32(context.Request.Form["txtSA"]);
        //num++;
        //post请求使用Form读取用户输入的值
        string userName = context.Request.Form["txtName"];
        string userPwd = context.Request.Form["txtPwd"];
        //替换参数内容
        //fileContent = fileContent.Replace("$name", userName).Replace("$pwd", userPwd);
        //fileContent = fileContent.Replace("$num", num.ToString());
        //将替换后的内容输出到浏览器
        context.Response.Write(fileContent);
    }



    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}