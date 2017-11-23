using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Admin/Error/

        public PartialViewResult In404()
        {
            return PartialView();
        }

        public PartialViewResult In500()
        {
            return PartialView();
        }
    }
}
