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
        /// 接口授权
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsAuthorized(string userId, string controller, string action,int rightTypes)
        {
            return dal.IsAuthorized(userId, controller, action, rightTypes);
        }
    }
}
