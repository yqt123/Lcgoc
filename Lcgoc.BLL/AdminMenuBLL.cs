using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;

namespace Lcgoc.BLL
{
    public class AdminMenuBLL
    {
        AdminMenuDAL dal = new AdminMenuDAL();
        public IEnumerable<admin_menu> GetAdminMenu(string code, string userId)
        {
            return dal.GetAdminMenu(code, userId);
        }

        public IEnumerable<admin_menu_detail> GetAdminMenuDetail(string code, string sequence, string userId)
        {
            return dal.GetAdminMenuDetail(code, sequence, userId);
        }

        /// <summary>
        /// 创建菜单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateMenu(admin_menu model)
        {
            return dal.CreateMenu(model);
        }

        /// <summary>
        /// 创建菜单明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateMenuDetail(admin_menu_detail model)
        {
            return dal.CreateMenuDetail(model);
        }
    }
}
