using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayer.DAL;
using ThreeLayer.Model;

namespace ThreeLayer.BLL
{
    public class UserInfoService
    {

        public List<UserInfo> GetList()
        {
            //在之后的业务层实现一些运算的功能
            return UserInfoDal.GetUserInfoList();
        }

        public List<UserInfo> GetUserInfoPageList(int pageSize, int pageIndex)
        {
            return UserInfoDal.GetPageList(pageSize, pageIndex);
        }

        //public int GetPageCount(int pageSize)
        //{
        //    return Math.Round(UserInfoDal.GetPageTotalCount() / pageSize,0);
        //}

        public bool IsAdded(UserInfo userInfo)
        {
            return UserInfoDal.AddUserInfo(userInfo) > 0;
        }

        public bool IsDeleted(UserInfo userInfo)
        {
            return UserInfoDal.DeleteInfo(userInfo) > 0;
        }

        public bool IsUpdated(UserInfo userInfo)
        {
            return UserInfoDal.UpdateUserInfo(userInfo) > 0;
        }

        public UserInfo GetUserInfoById(string CId)
        {
            return UserInfoDal.GetUserInfoById(CId);
        }


    }
}
