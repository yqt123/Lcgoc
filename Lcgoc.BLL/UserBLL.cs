using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;

namespace Lcgoc.BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();
        public bool IsAuthorized(string userName, string password, ref string userId)
        {
            return dal.IsAuthorized(userName, password, ref userId);
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            return dal.GetUser(userId);
        }
    }
}
