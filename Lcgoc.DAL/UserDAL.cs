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
        public bool IsAuthorized(string userName, string password)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = string.Empty;
                var myparams = new DynamicParameters(new { userName = userName, password = password });

                spsql = "SELECT 1 from `user` where (`userName`=@userName or `mobile`=@userName or `email`=@userName) and `password`=@password and allowUsed=1;";

                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    //return grids.Read<admin_menu>();
                }

            }
        }
        
    }
}
