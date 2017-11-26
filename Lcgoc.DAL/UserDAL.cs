using Dapper;
using Lcgoc.Common;
using Lcgoc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lcgoc.DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 用户授权认证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password">加密后的密码</param>
        /// <returns></returns>
        public bool IsAuthorized(string userName, string password,ref string userId)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT userId from `user` where (`userName`=@userName or `mobile`=@userName or `email`=@userName) and `password`=@password and allowUsed=1;";
                var myparams = new DynamicParameters(new { userName = userName, password = password });
                var res = connection.ExecuteScalar(spsql, myparams);
                if (res != null && !string.IsNullOrEmpty(res.ToString()))
                {
                    userId = res.ToString();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT * from `user` where `userId`=@userId and allowUsed=1;";
                var myparams = new DynamicParameters(new { userId = userId });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    return grids.Read<User>().FirstOrDefault();
                }
            }
        }
    }
}
