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
        public IEnumerable<admin_menu> GetAdminMenu(int pageSize, int pageIndex, string code, string name, string userId, ref int total)
        {
            return dal.GetAdminMenu(pageSize, pageIndex, code, name, userId, ref total);
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
        public bool CreateEditMenu(admin_menu model)
        {
            return dal.CreateEditMenu(model);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteMenu(string ids)
        {
            return dal.DeleteMenu(ids);
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
