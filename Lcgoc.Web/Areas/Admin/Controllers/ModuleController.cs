using Lcgoc.BLL;
using Lcgoc.Model;
using Lcgoc.Web.Models;
using Newtonsoft.Json;
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
    public class ModuleController : BaseController
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

        [HttpGet]
        public JsonResult ActionGet(int pageSize, int pageIndex, string module, string actionCode)
        {
            var user = WebConfig.GetUser();
            Dictionary<string, string> dis = new Dictionary<string, string>();
            foreach (var item in Request.QueryString.AllKeys)
            {
                switch (item)
                {
                    case "pageSize":
                    case "pageIndex":
                    case "module":
                    case "actionCode":
                    case "_": break;
                    default: dis.Add(item, Request.QueryString[item]); break;
                }
            }
            var res = bll.Query(pageSize, pageIndex, module, actionCode, user.userId, dis);
            //return new JsonResult() { Data = new { total = res.Count(), rows = res }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return base.NewtonsoftJson(new { total = res.Count(), rows = res }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ActionPost(FormCollection form)
        {
            Dictionary<string, string> dis = new Dictionary<string, string>();

            var actionCode = Request.Params["actionCode"].ToString();

            ModuleModel model = new ModuleModel();

            return View(model);
        }

    }
}
