using Lcgoc.Model;
using Lcgoc.Web.Areas.Admin.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 权限控制器基类
    /// </summary>
    public abstract class AbsRightController : Controller, IRightController
    {
        public override ActionResult PostAdd(FormCollection collection)
        {
            return View();
        }

        /// <summary>
        /// View删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PostDelete(admin_menu model);

        /// <summary>
        /// View修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult PostEdit(admin_menu model);

        /// <summary>
        /// Json新增
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult JsonAdd(FormCollection collection, string rightMessage);

        /// <summary>
        /// Json删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult JsonDelete(admin_menu model, string rightMessage);

        /// <summary>
        /// Json修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult JsonEdit(admin_menu model, string rightMessage);
    }
}
