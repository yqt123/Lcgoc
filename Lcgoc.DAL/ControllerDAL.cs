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
    public class ControllerDAL
    {
        /// <summary>
        /// 接口授权
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsAuthorized(string userId, string controller, string action)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = @"
SELECT 1 from admin_menu_detail_right a
INNER JOIN sys_controller b On a.controller=b.controller AND b.allowUsed=1
INNER JOIN sys_controller_action c On b.controller=c.controller AND a.action=c.action AND c.allowused=1
where a.userId=@userId AND a.controller=@controller AND a.action=@action;";
                var myparams = new DynamicParameters(new { userId = userId, controller = controller, action = action });
                var res = connection.ExecuteScalar(spsql, myparams);
                if (res != null && res.ToString()=="1")
                {
                    return true;
                }
            }
            return true;
        }
    }
}
