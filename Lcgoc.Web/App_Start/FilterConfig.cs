using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            ////登录验证
            filters.Add(new CustomAuthorizeAttribute());
            ////异常处理
            //filters.Add(new ExceptionLogAttribute());

        }
    }
}