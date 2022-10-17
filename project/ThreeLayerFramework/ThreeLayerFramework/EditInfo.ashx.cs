using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayer.BLL;
using ThreeLayer.Model;

namespace ThreeLayerFramework
{
    /// <summary>
    /// EditInfo 的摘要说明
    /// </summary>
    public class EditInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
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
            UserInfo userInfo = new UserInfo();
            userInfo.CName = courseName;
            userInfo.CId = courseId;
            userInfo.CTeacher = courseTeacher;
            userInfo.CCredit = credit;
            userInfo.CGrade = grade;
            UserInfoService service = new UserInfoService();
            if (service.IsUpdated(userInfo))
            {
                context.Response.Redirect("ShowInfo.aspx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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
}