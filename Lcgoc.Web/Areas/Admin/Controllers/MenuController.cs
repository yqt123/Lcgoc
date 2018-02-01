using Lcgoc.BLL;
using Lcgoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenuController : Controller
    {
        //
        // GET: /Admin/Report/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="code">菜单编码</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMenus(int pageSize, int pageIndex, string code, string name)
        {
            var total = 0;
            var menus = new AdminMenuBLL().GetAdminMenu(pageSize, pageIndex, code, name, "", ref total);
            return new JsonResult() { Data = new { total = total, rows = menus }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(string ids)
        {
            BaseResponse response = new BaseResponse();
            response.SetStatus(new AdminMenuBLL().DeleteMenu(ids));
            return new JsonResult() { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 创建或修改菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CreateEdit(admin_menu model)
        {
            BaseResponse response = new BaseResponse();
            response.SetStatus(new AdminMenuBLL().CreateEditMenu(model));
            return new JsonResult() { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
