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
        public userAuthorized LoginAuthorized(string userName, string password)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = @"
SELECT a.userId,a.userName,b.roleIds
from `user` a
LEFT JOIN (
SELECT userId,GROUP_CONCAT(roleId) roleIds from user_role where allowused=1 group by userId
)b ON a.userId=b.userId
where (a.`userName`=@userName or a.`mobile`=@userName or a.`email`=@userName) and a.`password`=@password and a.allowUsed=1;";
                var myparams = new DynamicParameters(new { userName = userName, password = password });
                var res = connection.Query<userAuthorized>(spsql, myparams);
                return res.FirstOrDefault();
            }
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

        /// <summary>
        /// 通过Token获取身份
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public crm_loginToken GetIdentityToken(string token)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT * from `crm_loginToken` where `token`=@token and date_add(createDate, interval ExpiresDays day)>NOW();";
                var myparams = new DynamicParameters(new { token = token });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    return grids.Read<crm_loginToken>().FirstOrDefault();
                }
            }
        }

        /// <summary>
        /// 更新登录认证
        /// </summary>
        /// <param name="data"></param>
        public void RefreshLoginToken(crm_loginToken_log data, int ExpiresDays)
        {
            using (var connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { inidentity = data.identity, intoken = data.token, inip = data.ip, inuserAgent = data.userAgent, inExpiresDays = ExpiresDays });
                connection.Execute("sp_crm_RefreshLoginToken", myparams, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 获取登录Token日志
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public IEnumerable<crm_loginToken_log> GetLoginTokenLog(string identity)
        {
            using (var connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT * from `crm_loginToken_log` where `identity`=@identity;";
                var myparams = new DynamicParameters(new { identity = identity });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    return grids.Read<crm_loginToken_log>();
                }
            }
        }

    }
}
