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
                var user = filterContext.HttpContext.Session[WebConfig.LoginSessionName];
                if (user == null)
                {
                    //var result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                    filterContext.Result = new RedirectResult("~/Admin/Account/Login?returnUrl=" + HttpUtility.UrlEncode(controllerName + "/" + actionName));
                }
                //判断webconfig是否开启数据库权限判断
                else if (WebConfig.OpenRightControl && !new ControllerBLL().IsAuthorized(((User)user).userId, controllerName, actionName, (int)RightTypes))
                {
                    if (filterContext.ActionParameters.ContainsKey("rightMessage"))
                        filterContext.ActionParameters["rightMessage"] = "您没有此权限：" + controllerName + "/" + actionName + "/" + RightTypes.ToString();
                    else
                        filterContext.Result = new RedirectResult("~/Admin/Error/NotRight?returnUrl=" + HttpUtility.UrlEncode(controllerName + "/" + actionName + "/" + RightTypes.ToString()));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}