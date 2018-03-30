using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;
using System.Data;

namespace Lcgoc.BLL
{
    public class ModuleBLL
    {
        ModuleDAL dal = new ModuleDAL();
        public IEnumerable<module> GetModule(string moduleCode = "")
        {
            return dal.GetModule(moduleCode);
        }

        public IEnumerable<module_actions> GetModuleActions(string moduleCode = "", string actionCode = "")
        {
            return dal.GetModuleActions(moduleCode, actionCode);
        }

        public IEnumerable<module_actions_query> GetModuleActionsQuery(string moduleCode = "", string actionCode = "", string queryCode = "")
        {
            return dal.GetModuleActionsQuery(moduleCode, actionCode, queryCode);
        }

        public IEnumerable<module_actions_columns> GetModuleActionsColumns(string moduleCode = "", string actionCode = "", string columnCode = "")
        {
            return dal.GetModuleActionsColumns(moduleCode, actionCode, columnCode);
        }

        public List<dynamic> Query(int pageSize, int pageIndex, string moduleCode, string actionCode, string userId, Dictionary<string, string> dic)
        {
            var billNo = "";
            dal.CreateQueue(pageSize, pageIndex, moduleCode, actionCode, userId, dic, ref billNo);
            return dal.Query(userId, billNo);
        }

    }
}
