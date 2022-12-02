<%@ WebHandler Language="C#" Class="DeleteCourse" %>

using System;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DeleteCourse : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string courseId = context.Request.QueryString["课程代码"];
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conStr))
        {
            string sql = "delete from Course where [课程代码] = @课程代码";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlParameter par = new SqlParameter("@课程代码", SqlDbType.NVarChar);
                par.Value = courseId;
                cmd.Parameters.Add(par);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    context.Response.Write("删除成功！");
                    context.Response.Redirect("QueryAll.ashx", false);
                }
                else
                {
                    context.Response.Write("删除失败！");
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