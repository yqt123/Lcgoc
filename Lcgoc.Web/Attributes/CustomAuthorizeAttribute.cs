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
        /// <summary>
        /// 匿名访问
        /// </summary>
        public bool AllowAnonymous { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("HttpContext");
            }
            if (AllowAnonymous)
            {
                return true;
            }
            if (Roles == null)
            {
                return true;
            }
            if (Roles.Length == 0)
            {
                return true;
            }

            var identity = System.Web.HttpContext.Current.Session[WebConfig.LoginSessionName];
            if (identity == null)
            {//没有登录则判断是否有记住密码的cookie
                HttpCookie cookie = HttpContext.Current.Request.Cookies[WebConfig.LoginTokenName];
                if (cookie == null || cookie.Value == null)
                {
                    httpContext.Response.StatusCode = 401;
                    return false;
                }
                else
                {
                    var identityData = new UserBLL().GetIdentityToken(cookie.Value);
                    if (identityData != null)
                    {
                        identity = identityData.identity;
                        System.Web.HttpContext.Current.Session[WebConfig.LoginSessionName] = identityData.identity;
                        return true;
                    }
                }
                httpContext.Response.StatusCode = 401;
                return false;
            }
            var entity = identity as userAuthorized;
            if (entity == null)
            {
                httpContext.Response.StatusCode = 401;
                return false;
            }
            if (string.IsNullOrEmpty(entity.roleIds))
            {
                httpContext.Response.StatusCode = 401;
                return false;
            }

            var userRoleIds = entity.roleIds.Split(',');
            var roleRight = Roles.Any(n => { if (userRoleIds.Contains(n)) return true; else return false; });
            if (roleRight)
            {
                return true;
            }
            else
            {//没有权限
                httpContext.Response.StatusCode = 402;
                return false;
            }
        }

        /// <summary>
        /// 在AuthorizeCore前执行，读取控制器对应角色
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute), true))
            {
                AllowAnonymous = false;
                string area = string.Empty;
                var _area = filterContext.RouteData.DataTokens["area"];
                if (_area != null)
                    area = filterContext.RouteData.DataTokens["area"].ToString();

                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string actionName = filterContext.ActionDescriptor.ActionName;
                this.Roles = new ControllerBLL().GetActionRoles(area, controllerName, actionName);
            }
            else
            {
                AllowAnonymous = true;
            }
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
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", area = "Admin" }));
            }
            if (filterContext.HttpContext.Response.StatusCode == 402)
            {
                filterContext.HttpContext.Response.Write(" <script type='text/javascript'> alert('您没有此操作的权限！');</script>");
                filterContext.RequestContext.HttpContext.Response.End();
                filterContext.Result = new EmptyResult();
            }
        }
    }
}