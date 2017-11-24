using Lcgoc.Web.Areas.Admin.Filters;
using Lcgoc.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            if (ModelState.IsValid)
            {
                System.Web.HttpContext.Current.Session["User"] = model.UserName;
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "提供的账号或密码不正确。");
            }
            return View(model);
        }
    }
}
