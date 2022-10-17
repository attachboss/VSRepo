using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayer.BLL;
using ThreeLayer.Model;

namespace ThreeLayerFramework
{
    public partial class EditInfo : System.Web.UI.Page
    {
        public UserInfo userInfo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //表示本次请求是get请求
            if (!IsPostBack)
            {
                UpdateProcessFillIn();
            }
            else//表示post请求
            {
                UpdateProcessApply();
            }
        }

        protected void UpdateProcessApply()
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
            UserInfo userInfo = new UserInfo();
            userInfo.CName = courseName;
            userInfo.CId = courseId;
            userInfo.CTeacher = courseTeacher;
            userInfo.CCredit = credit;
            userInfo.CGrade = grade;
            UserInfoService service = new UserInfoService();
            if (service.IsUpdated(userInfo))
            {
                Response.Redirect("ShowInfo.aspx");
            }
            else
            {
                Response.Redirect("Error.html");
            }
        }

        protected void UpdateProcessFillIn()
        {
            string id = Request.QueryString["CId"];
            ThreeLayer.BLL.UserInfoService service = new ThreeLayer.BLL.UserInfoService();
            UserInfo info = service.GetUserInfoById(id);
            if (info != null)
            {
                userInfo = info;
            }
            else
            {
                Response.Redirect("Error.html");
            }
        }
    }
}