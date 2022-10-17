using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace ThreeLayerFramework.FileResource
{
    /// <summary>
    /// ProcessFileUp 的摘要说明
    /// </summary>
    public class ProcessFileUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HttpPostedFile file = context.Request.Files[0];
            if (file.ContentLength > 0)
            {
                //获取文件名称(包含扩展名)
                string fileName = Path.GetFileName(file.FileName);
                //获取文件扩展名
                string fileExtName = Path.GetExtension(file.FileName);
                if (Regex.IsMatch(fileExtName, @"^/.[a-z]+$"))
                {
                    file.SaveAs(context.Request.MapPath(@"/File/" + fileName));
                    context.Response.Write("<html><body><img src='File/" + fileName +"'></body></html>");
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
}