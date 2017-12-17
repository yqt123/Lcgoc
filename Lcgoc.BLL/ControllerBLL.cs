using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;

namespace Lcgoc.BLL
{
    public class ControllerBLL
    {
        ControllerDAL dal = new ControllerDAL();
        /// <summary>
        /// 获取方法对应角色
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public string[] GetActionRoles(string area, string controller, string action)
        {
            return dal.GetActionRoles(area, controller, action);
        }
    }
}
