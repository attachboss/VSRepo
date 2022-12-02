using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayer.BLL;

namespace ThreeLayerFramework
{
    public partial class InsertInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //表示本次请求是post请求
            if (!String.IsNullOrEmpty(Request.Form["IsPostBack"]))
            {
                InsertInfoProcess();
            }
        }

        /// <summary>
        /// 执行BLL返回结果之后将页面重定向至主页面
        /// </summary>
        protected void InsertInfoProcess()
        {
            string courseName = Request.Form["txtName"];
            string courseId = Request.Form["txtId"];
            string courseTeacher = Request.Form["txtTeacher"];
            string courseCredit = Request.Form["txtCredit"];
            int credit;
            bool b = int.TryParse(courseCredit, out credit);
            string courseGrade = Request.Form["txtGrade"];
            float grade;
            b = float.TryParse(courseGrade, out grade);
            if (b == false)
            {
                //当转换失败时不继续执行
                Response.Write("参数错误！");
                return;
            }
            ThreeLayer.Model.UserInfo userInfo = new ThreeLayer.Model.UserInfo();
            userInfo.CName = courseName;
            userInfo.CId = courseId;
            userInfo.CTeacher = courseTeacher;
            userInfo.CCredit = credit;
            userInfo.CGrade = grade;
            UserInfoService service = new UserInfoService();
            if (service.IsAdded(userInfo))
            {
                Response.Redirect("ShowInfo.aspx");
            }
            else
            {
                Response.Redirect("Error.html");
            }
        }
    }
}