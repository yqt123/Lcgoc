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
        /// 获取方法对应角色
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public string[] GetActionRoles(string area, string controller, string action)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT GROUP_CONCAT(roleId) roleIds from sys_controller_action_role where area=@area and controller=@controller and action=@action and allowused=1 group by controller,action;";
                var myparams = new DynamicParameters(new { area = area, controller = controller, action = action });
                var res = connection.ExecuteScalar(spsql, myparams);
                if (res != null && !string.IsNullOrEmpty(res.ToString()))
                    return res.ToString().Split(',');
                return null;
            }
        }
    }
}
