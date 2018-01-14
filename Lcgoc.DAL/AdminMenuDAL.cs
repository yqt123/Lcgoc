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
    public class AdminMenuDAL
    {
        /// <summary>
        /// 查找菜单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<admin_menu> GetAdminMenu(int pageSize, int pageIndex, string code, string name, string userId, ref int total)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { inpageSize = pageSize, inpageIndex = pageIndex, incode = code, inname = name, inuserId = userId });
                myparams.Add("outtotal", total, DbType.Int16, ParameterDirection.Output);
                var res = connection.Query<admin_menu>("sp_GetAdminMenu", myparams, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// 获取菜单明细
        /// </summary>
        /// <param name="code"></param>
        /// <param name="sequence"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<admin_menu_detail> GetAdminMenuDetail(string code, string sequence, string userId)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = string.Empty;
                var myparams = new DynamicParameters();
                if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(sequence))
                {
                    spsql = "SELECT * from admin_menu_detail where `code`=@code and sequence=@sequence and allowUsed=1 ORDER BY `level` ASC;";
                    myparams.Add("code", code);
                    myparams.Add("sequence", sequence);
                }
                else
                {
                    spsql = "SELECT * from admin_menu_detail where allowUsed=1 ORDER BY `level` ASC;";
                }

                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    return grids.Read<admin_menu_detail>();
                }
            }
        }

        /// <summary>
        /// 创建菜单信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateEditMenu(admin_menu model)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                var myparams = new DynamicParameters(new { incode = model.code, inicon = model.icon, inname = model.name, inallowused = model.allowused, inlevel = model.level, inpullRightContainer = model.pullRightContainer });
                var res = connection.Execute("sp_CreateEditMenu", myparams, commandType: CommandType.StoredProcedure);
                return res > 0;
            }
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteMenu(string ids)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                StringBuilder sb = new StringBuilder();
                var myparams = new DynamicParameters();
                var listIds = ids.Split(',');
                for (int n = 0; n < listIds.Length; n++)
                {
                    sb.Append("DELETE FROM admin_menu where `code`=@code" + n + ";");
                    myparams.Add("@code" + n, listIds[n]);
                }
                var res = connection.Execute(sb.ToString(), myparams);
                return res > 0;
            }
        }

        /// <summary>
        /// 创建菜单明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CreateMenuDetail(admin_menu_detail model)
        {
            return true;
        }
    }
}
