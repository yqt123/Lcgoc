using Lcgoc.BLL;
using Lcgoc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        UserBLL bll = new UserBLL();
        //
        // GET: /Admin/Account/
        [HttpGet]
        [CustomAllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [CustomAllowAnonymous]
        //防止跨站攻击
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string userId = string.Empty;
                var res = bll.LoginAuthorized(model.UserName, model.Password);
                if (res != null && !string.IsNullOrEmpty(res.userId))
                {
                    Services.AuthorizationManager.SetAdminTicket(model.RememberMe, res);
                    if (!string.IsNullOrEmpty(returnUrl) && HttpUtility.UrlDecode(returnUrl).Split('/').Length == 2)
                    {
                        var controllerAction = HttpUtility.UrlDecode(returnUrl).Split('/');
                        return RedirectToAction(controllerAction[1], controllerAction[0]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "提供的账号或密码不正确。");
            return View(model);
        }

    }
}
