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
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetMenus(string code)
        {
            var menus = new AdminMenuBLL().GetAdminMenu("", user.userId);
            return new JsonResult() { Data = menus, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage">权限控制时返回的提示</param>
        /// <returns></returns>
        [HttpPost]
        //防止跨站攻击
        [ValidateAntiForgeryToken]
        public JsonResult Create(admin_menu model, string rightMessage)
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
            return new JsonResult() { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        //防止跨站攻击
        [ValidateAntiForgeryToken]
        public JsonResult Delete(admin_menu model, string rightMessage)
        {
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError("", "保存失败！");
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
