using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lcgoc.Web.Areas.Admin.Filters
{
    /// <summary>
    /// 控制器权限
    /// </summary>
    public class RightControlAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //判断是否设置有方法控制权限
            if (!filterContext.ActionDescriptor.IsDefined(typeof(RightControlAllowAnonymous), true))
            {
                var actionName = filterContext.ActionDescriptor.ActionName;
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (filterContext.HttpContext.Session["admin_cookies"] == null)
                {
                    //var result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                    filterContext.Result = new RedirectResult("~/Admin/Account/Login?returnUrl=" + HttpUtility.UrlEncode(controllerName + "/" + actionName));
                }
                //判断webconfig是否开启数据库权限判断
                if (WebConfig.OpenRightControl)
                {
                    filterContext.Result = new RedirectResult("~/Admin/Error/NotRight?returnUrl=" + HttpUtility.UrlEncode(controllerName + "/" + actionName));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}