using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        [CustomAllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }

}
