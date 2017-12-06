using Lcgoc.BLL;
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
    [ControlRight]
    public class AccountController : Controller
    {
        UserBLL bll = new UserBLL();
        //
        // GET: /Admin/Account/
        [HttpGet]
        [ControlRightAllowAnonymousAttribute]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ControlRightAllowAnonymousAttribute]
        //防止跨站攻击
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string userId = string.Empty;
                if (bll.IsAuthorized(model.UserName, model.Password, ref userId))
                {
                    var user = bll.GetUser(userId);
                    //
                    System.Web.HttpContext.Current.Session[WebConfig.LoginCookieName] = user;
                    
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
