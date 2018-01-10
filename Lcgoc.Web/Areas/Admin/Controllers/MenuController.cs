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
        Lcgoc.Model.userAuthorized user = WebConfig.GetUser();
        //
        // GET: /Admin/Report/
        [HttpGet]
        public ActionResult Index()
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
            var user = WebConfig.GetUser();
            var total = 0;
            var menus = new AdminMenuBLL().GetAdminMenu(pageSize, pageIndex, code, name, user.userId, ref total);
            return new JsonResult() { Data = new { total = total, rows = menus }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //防止跨站攻击
        [ValidateAntiForgeryToken]
        public JsonResult Create(admin_menu model)
        {
            BaseResponse<string> res = new BaseResponse<string>();
            if (ModelState.IsValid && new AdminMenuBLL().CreateMenu(model))
            {
                res.Code = ResponseCodeEnum.Success;
            }
            else
            {
                res.Code = ResponseCodeEnum.Fail;
                res.Error = "保存失败！";
            }
            ModelState.AddModelError("", "保存失败！");
            return new JsonResult() { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        //防止跨站攻击
        [ValidateAntiForgeryToken]
        public JsonResult Delete(admin_menu model)
        {
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        //新增或修改
        [ValidateAntiForgeryToken]
        public JsonResult GetEdit(admin_menu model)
        {
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
