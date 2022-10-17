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
    public partial class ShowInfo : System.Web.UI.Page
    {
        public List<UserInfo> List { get; set; }
        private int pageSize = 5;
        public int pageIndex = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
            {
                pageIndex = 1;
            }
            UserInfoService service = new UserInfoService();
            //int pageCount = service
            //pageIndex = pageIndex < 1 ? 1 : pageIndex;

            List = service.GetUserInfoPageList(pageSize, pageIndex);
        }
    }
}