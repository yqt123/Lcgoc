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
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public new string[] Roles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("HttpContext");
            }
            var identity = System.Web.HttpContext.Current.Session[WebConfig.LoginSessionName];
            if (identity==null)
            {//没有登录则判断是否有记住密码的cookie
                HttpCookie cookie = HttpContext.Current.Request.Cookies[WebConfig.LoginTokenName];
                return false;
            }
            //没有设置权限，则都可以访问
            if (Roles == null)
            {
                return true;
            }
            if (Roles.Length == 0)
            {
                return true;
            }
            if (Roles.Any(httpContext.User.IsInRole))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在AuthorizeCore前执行，读取控制器对应角色
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            this.Roles = new ControllerBLL().GetActionRoles(actionName, controllerName);
            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// 在AuthorizeCore返回false时执行，处理未能授权的Http请求
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