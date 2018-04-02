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
            var user = WebConfig.GetUser();
            if (user == null || string.IsNullOrEmpty(user.roleIds))
            {
                httpContext.Response.StatusCode = 401;
                return false;
            }
            var userRoleIds = user.roleIds.Split(',');
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
                //模块通用操作方法，判断输入的模块有误权限
                if (controllerName == "Module")
                {
                    var module = filterContext.RequestContext.HttpContext.Request.Params["_module"];
                    if (!string.IsNullOrEmpty(module))
                        controllerName = module.ToString();
                    if (actionName == "ActionGet" || actionName == "ActionPost")
                    {
                        var action = filterContext.RequestContext.HttpContext.Request.Params["_action"];
                        if (!string.IsNullOrEmpty(action))
                        {
                            actionName = action;
                        }
                    }
                }

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
                //filterContext.HttpContext.Response.Write(" <script type='text/javascript'> alert('您没有此操作的权限！');</script>");
                filterContext.HttpContext.Response.Write(" 您没有此操作的权限！");
                filterContext.RequestContext.HttpContext.Response.End();
                filterContext.Result = new EmptyResult();
            }
        }
    }
}