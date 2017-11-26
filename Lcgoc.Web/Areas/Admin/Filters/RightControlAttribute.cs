using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                if (filterContext.HttpContext.Session["admin_cookies"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Admin/Account/Login?returnUrl=" + filterContext.Result);
                }
                var actionName= filterContext.ActionDescriptor.ActionName;
                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                //判断webconfig是否开启数据库权限判断
                if (WebConfig.OpenRightControl)
                {
                    base.OnActionExecuting(filterContext);
                    filterContext.HttpContext.Response.Write("你没有操作权限，如有需要请联系相关人员！");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}