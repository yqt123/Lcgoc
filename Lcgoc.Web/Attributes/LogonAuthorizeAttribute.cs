using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lcgoc.BLL;
using Lcgoc.Model;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lcgoc.Web
{
    /// <summary>
    /// 后台登录验证
    /// </summary>
    public class LogonAuthorizeAttribute : AuthorizeAttribute
    {
        public new string[] Roles { get; set; }
        /// <summary>
        /// 提供一个入口用于自定义授权检查
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool pass = false;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[WebConfig.LoginTokenName];
            if (cookie == null || cookie.Value == null)
            {
                httpContext.Response.StatusCode = 401;
                pass = false;
            }
            else
            {
                pass = true;
            }
            return pass;
        }

        /// <summary>
        /// 处理未能授权的Http请求
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (filterContext.HttpContext.Response.StatusCode == 401)
            {
                //跳转到登录界面
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
        }
    }
}