using Lcgoc.Web.Areas.Admin.Filters;
using Lcgoc.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    [RightControl]
    public class AccountController : Controller
    {
        //
        // GET: /Admin/Account/
        [HttpGet]
        [RightControlAllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [RightControlAllowAnonymous]
        //防止了跨站攻击
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {

            return View(model);
        }
    }
}
