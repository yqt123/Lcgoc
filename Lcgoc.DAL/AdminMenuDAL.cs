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
        public IEnumerable<admin_menu> GetAdminMenu(string code,string userId)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = string.Empty;
                var myparams = new DynamicParameters();
                if (!string.IsNullOrEmpty(code))
                {
                    spsql = "SELECT * from admin_menu where `code`=@code and allowUsed=1 ORDER BY `level` ASC;";
                    myparams.Add("code", code);
                }
                else
                {
                    spsql = "SELECT * from admin_menu where allowUsed=1 ORDER BY `level` ASC;";
                }
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    return grids.Read<admin_menu>();
                }
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
        public bool CreateMenu(admin_menu model)
        {
            return true;
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
