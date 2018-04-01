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
    public class ModuleDAL
    {
        CommonDAL cdal = new CommonDAL();

        public IEnumerable<module> GetModule(string moduleCode = "")
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { moduleCode = moduleCode });
                var sqlstr = "SELECT * FROM module";
                if (!string.IsNullOrEmpty(moduleCode))
                {
                    sqlstr += " where moduleCode=@moduleCode;";
                }
                var res = connection.Query<module>(sqlstr, myparams);
                return res;
            }
        }

        public IEnumerable<module_actions> GetModuleActions(string moduleCode = "", string actionCode = "")
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { moduleCode = moduleCode, actionCode = actionCode });
                var sqlstr = "SELECT * FROM module_actions";
                if (!string.IsNullOrEmpty(moduleCode))
                {
                    sqlstr += " where moduleCode=@moduleCode";
                }
                if (!string.IsNullOrEmpty(actionCode))
                {
                    sqlstr += " and actionCode=@actionCode;";
                }
                var res = connection.Query<module_actions>(sqlstr, myparams);
                return res;
            }
        }

        public IEnumerable<module_actions_query> GetModuleActionsQuery(string moduleCode = "", string actionCode = "", string queryCode = "")
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { moduleCode = moduleCode, actionCode = actionCode, queryCode = queryCode });
                var sqlstr = "SELECT * FROM module_actions_query";
                if (!string.IsNullOrEmpty(moduleCode))
                {
                    sqlstr += " where moduleCode=@moduleCode";
                }
                if (!string.IsNullOrEmpty(actionCode))
                {
                    sqlstr += " and actionCode=@actionCode";
                }
                if (!string.IsNullOrEmpty(queryCode))
                {
                    sqlstr += " and queryCode=@queryCode";
                }
                sqlstr += " ORDER BY `level` ASC";
                var res = connection.Query<module_actions_query>(sqlstr, myparams);
                return res;
            }
        }

        public IEnumerable<module_actions_columns> GetModuleActionsColumns(string moduleCode = "", string actionCode = "", string columnCode = "")
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { moduleCode = moduleCode, actionCode = actionCode, columnCode = columnCode });
                var sqlstr = "SELECT * FROM module_actions_columns";
                if (!string.IsNullOrEmpty(moduleCode))
                {
                    sqlstr += " where moduleCode=@moduleCode";
                }
                if (!string.IsNullOrEmpty(actionCode))
                {
                    sqlstr += " and actionCode=@actionCode";
                }
                if (!string.IsNullOrEmpty(columnCode))
                {
                    sqlstr += " and columnCode=@columnCode";
                }
                sqlstr += " ORDER BY `level` ASC";
                var res = connection.Query<module_actions_columns>(sqlstr, myparams);
                return res;
            }
        }

        /// <summary>
        /// 创建数据队列
        /// </summary>
        /// <returns></returns>
        public void CreateQueue(int pageSize, int pageIndex, string moduleCode, string actionCode, string userId, Dictionary<string, string> dic, ref string billNo)
        {
            billNo = cdal.GetMaxBillNo("Q");
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                StringBuilder sqlsb = new StringBuilder();
                sqlsb.Append(string.Format("INSERT INTO module_queue(queueCode,`describe`,allowused,modifyDTM,moduleCode,actionCode,userId) VALUES('{0}','{1}',1,NOW(),'{2}','{3}','{4}');", billNo, "", moduleCode, actionCode, userId));
                var sequence = 1;
                foreach (var item in dic)
                {
                    var keyword = 0;
                    var id = item.Key;
                    if (item.Key.EndsWith("_keyword"))
                    {
                        id = id.Substring(0, id.Length - 8);
                        keyword = 1;
                    }
                    sqlsb.Append(string.Format("INSERT INTO module_queue_detail(queueCode,sequence,id,`value`,`keyword`) VALUES('{0}','{1}','{2}','{3}','{4}');", billNo, sequence, id, item.Value, keyword));
                    sequence++;
                }
                using (var tran = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute(sqlsb.ToString(), transaction: tran);
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                    tran.Dispose();
                }
            }
        }

        /// <summary>
        /// 模块查询
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="queueCode"></param>
        /// <returns></returns>
        public List<dynamic> Query(string userId, string queueCode)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { inuserId = userId, inqueueCode = queueCode });
                var res = connection.Query("sp_ModuleQuery", myparams, commandType: CommandType.StoredProcedure).ToList();
                return res;
            }
        }

        public bool ActionPost(string userId, string queueCode)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                try
                {
                    var myparams = new DynamicParameters(new { inuserId = userId, inqueueCode = queueCode });
                    connection.Execute("sp_ModuleActionPost", myparams, commandType: CommandType.StoredProcedure);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}
