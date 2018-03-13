using Lcgoc.BLL;
using Lcgoc.Model;
using Lcgoc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ModuleController : Controller
    {
        ModuleBLL bll = new ModuleBLL();
        //
        // GET: /Admin/Report/
        [HttpGet]
        public ActionResult Index()
        {
            ModuleModel model = new ModuleModel();
            var moduleName = Request.Params["module"].ToString();
            model.module = bll.GetModule(moduleName).FirstOrDefault();
            model.actions = bll.GetModuleActions(moduleCode: moduleName);
            model.columns = bll.GetModuleActionsColumns(moduleCode: moduleName);
            model.query = bll.GetModuleActionsQuery(moduleCode: moduleName);
            return View(model);
        }

        [HttpPost]
        public ActionResult Action()
        {
            var actionCode = Request.Params["actionCode"].ToString();

            ModuleModel model = new ModuleModel();

            return View(model);
        }
    }
}
