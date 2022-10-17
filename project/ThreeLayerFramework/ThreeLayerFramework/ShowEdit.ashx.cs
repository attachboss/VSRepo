using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ThreeLayer.BLL;
using ThreeLayer.Model;

namespace ThreeLayerFramework
{
    /// <summary>
    /// ShowEdit 的摘要说明
    /// </summary>
    public class ShowEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string CId;
            CId = context.Request.QueryString["CId"];
            UserInfoService service = new UserInfoService();
            UserInfo userInfo = service.GetUserInfoById(CId);
            if (userInfo != null)
            {
                string filePath = context.Request.MapPath("ShowEdit.html");
                string fileContent = File.ReadAllText(filePath);
                fileContent = fileContent.Replace("$Name", userInfo.CName).Replace("$Id", userInfo.CId).Replace("$Teacher", userInfo.CTeacher).Replace("$Credit", userInfo.CCredit.ToString()).Replace("$Grade", userInfo.CGrade.ToString());
                context.Response.Write(fileContent);
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