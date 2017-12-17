using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lcgoc.Web.Areas.Admin.Filters;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Admin/Error/
        public ViewResult In404()
        {
            return View();
        }

        public ViewResult In500()
        {
            return View();
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        /// <returns></returns>
        [CustomAllowAnonymous]
        public ViewResult NotRight(string returnUrl)
        {
            ViewBag.Controller = "";
            ViewBag.Action = "";
            if (!string.IsNullOrEmpty(returnUrl) && HttpUtility.UrlDecode(returnUrl).Split('/').Length == 3)
            {
                var controllerAction = HttpUtility.UrlDecode(returnUrl).Split('/');
                ViewBag.Message = controllerAction[0] + "/" + controllerAction[1] + "/" + controllerAction[2];
            }
            return View();
        }
    }
}
