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
    /// 权限控制器
    /// </summary>
    [ControlRight]
    public interface IRightController
    {
        /// <summary>
        /// View新增
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PostAdd(FormCollection collection);

        /// <summary>
        /// View删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PostDelete(admin_menu model);

        /// <summary>
        /// View修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult PostEdit(admin_menu model);
        
        /// <summary>
        /// Json新增
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult JsonAdd(FormCollection collection, string rightMessage);

        /// <summary>
        /// Json删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult JsonDelete(admin_menu model, string rightMessage);

        /// <summary>
        /// Json修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult JsonEdit(admin_menu model, string rightMessage);
    }
}
