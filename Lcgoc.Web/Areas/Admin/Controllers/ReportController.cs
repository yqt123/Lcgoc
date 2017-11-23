using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    [Filters.RightControl]
    public class ReportController : Controller
    {
        //
        // GET: /Admin/Report/
        public PartialViewResult Index()
        {
            return PartialView();
        }

    }
}
