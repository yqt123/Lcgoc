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

        /// <summary>
        /// 获取登录Token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public crm_loginToken GetIdentityToken(string token)
        {
            return dal.GetIdentityToken(token);
        }

        /// <summary>
        /// 更新登录认证
        /// </summary>
        /// <param name="data"></param>
        public void RefreshLoginToken(crm_loginToken_log data, int ExpiresDays)
        {
            dal.RefreshLoginToken(data, ExpiresDays);
        }

        /// <summary>
        /// 获取登录Token日志
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IEnumerable<crm_loginToken_log> GetLoginTokenLog(string identity)
        {
            return dal.GetLoginTokenLog(identity);
        }
    }
}
