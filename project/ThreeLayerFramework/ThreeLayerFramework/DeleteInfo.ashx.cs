using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayer.BLL;
using ThreeLayer.Model;

namespace ThreeLayerFramework
{
    /// <summary>
    /// DeleteInfo 的摘要说明
    /// </summary>
    public class DeleteInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string courseId = context.Request.QueryString["CId"];
            UserInfo userInfo = new UserInfo();
            userInfo.CId = courseId;
            UserInfoService service = new UserInfoService();
            if (service.IsDeleted(userInfo))
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