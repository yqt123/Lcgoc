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

    }
}
