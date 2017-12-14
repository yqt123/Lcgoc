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
        public bool IsAuthorized(string userId, string controller, string action,int rightTypes)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var rightStr = string.Empty;
                switch (rightTypes)
                {
                    case 0: rightStr = "a.View=1"; break;
                    case 1: rightStr = "a.Add=1"; break;
                    case 2: rightStr = "a.Delete=1"; break;
                    case 3: rightStr = "a.Edit=1"; break;
                    default: rightStr = "1=1"; break;
                }
                string spsql = string.Format(@"
SELECT 1 from admin_menu_detail_right a
INNER JOIN sys_controller b On a.controller=b.controller AND b.allowUsed=1
INNER JOIN sys_controller_action c On b.controller=c.controller AND a.action=c.action AND c.allowused=1
where a.userId=@userId AND a.controller=@controller AND a.action=@action and {0};", rightStr);
                var myparams = new DynamicParameters(new { userId = userId, controller = controller, action = action });
                var res = connection.ExecuteScalar(spsql, myparams);
                if (res != null && res.ToString()=="1")
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取方法对应角色
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public string[] GetActionRoles(string controller, string action)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = @"SELECT GROUP_CONCAT(roleId) roleIds from sys_controller_action_role where controller=@controller and action=@action and allowused=1 group by controller,action";
                var myparams = new DynamicParameters(new { controller = controller, action = action });
                var res = connection.ExecuteScalar<string>(spsql, myparams);
                if (!string.IsNullOrEmpty(res))
                    return res.Split(',');
                return null;
            }
        }
    }
}
