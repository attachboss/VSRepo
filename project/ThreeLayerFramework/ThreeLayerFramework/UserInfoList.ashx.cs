using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using ThreeLayer.Model;

namespace ThreeLayerFramework
{
    /// <summary>
    /// UserInfoList 的摘要说明
    /// </summary>
    public class UserInfoList : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            ThreeLayer.BLL.UserInfoService service = new ThreeLayer.BLL.UserInfoService();
            List<UserInfo> list = service.GetList();
            StringBuilder sb = new StringBuilder();
            foreach (UserInfo userInfo in list)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td><a href='ShowEdit.ashx?CId={1}' class='editCourse'>编辑</a></td><td><a href='DeleteInfo.ashx?CId={1}' class='deleteCourse'>删除</a></td></tr>", userInfo.CName, userInfo.CId, userInfo.CTeacher, userInfo.CCredit, userInfo.CGrade);
            }
            string filePath = context.Request.MapPath("UserInfoUI.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("@tbody", sb.ToString());
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
}