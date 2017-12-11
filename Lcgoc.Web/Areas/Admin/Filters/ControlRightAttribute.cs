using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Lcgoc.BLL;
using Lcgoc.Model;

namespace Lcgoc.Web.Areas.Admin.Filters
{
    /// <summary>
    /// 控制器权限
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ControlRightAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 权限类型
        /// </summary>
        public RightTypesEnum RightTypes { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //判断是否设置有方法控制权限
            if (!filterContext.ActionDescriptor.IsDefined(typeof(ControlRightAllowAnonymousAttribute), true))
            {
                var actionName = filterContext.ActionDescriptor.ActionName;
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var identity = filterContext.HttpContext.Session[WebConfig.LoginSessionName];
                if (identity == null)
                {
                    var token = filterContext.HttpContext.Response.Cookies[WebConfig.LoginTokenName];
                    if (token != null)
                    {
                        var identityData = new UserBLL().GetIdentityToken(token.Value);
                        if (identityData != null)
                        {
                            identity = identityData.identity;
                            filterContext.HttpContext.Session[WebConfig.LoginSessionName] = identityData.identity;
                        }
                    }
                    if (identity == null)
                    {
                        var result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                        //filterContext.Result = new RedirectResult("~/Admin/Account/Login?returnUrl=" + HttpUtility.UrlEncode(controllerName + "/" + actionName));
                        filterContext.Controller.ViewData["returnUrl"] = HttpUtility.UrlEncode(controllerName + "/" + actionName);
                    }
                }

                //判断webconfig是否开启数据库权限判断
                if (identity != null && WebConfig.OpenRightControl && !new ControllerBLL().IsAuthorized(identity.ToString(), controllerName, actionName, (int)RightTypes))
                {
                    filterContext.HttpContext.Response.Write(" <script type='text/javascript'> alert('您没有此操作的权限！');</script>");
                    filterContext.RequestContext.HttpContext.Response.End();
                    filterContext.Result = new EmptyResult();
                    return;
                    //if (filterContext.ActionParameters.ContainsKey("rightMessage"))
                    //    filterContext.ActionParameters["rightMessage"] = "您没有此权限：" + controllerName + "/" + actionName + "/" + RightTypes.ToString();
                    //else
                    //    filterContext.Result = new RedirectResult("~/Admin/Error/NotRight?returnUrl=" + HttpUtility.UrlEncode(controllerName + "/" + actionName + "/" + RightTypes.ToString()));

                }
            }
            //base.OnAuthorization(filterContext);
        }
    }
}