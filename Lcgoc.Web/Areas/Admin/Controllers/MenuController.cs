using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    [Filters.RightControl]
    public class MenuController : Controller
    {
        //
        // GET: /Admin/Report/
        public PartialViewResult Index()
        {
            return PartialView();
        }

    }
}
