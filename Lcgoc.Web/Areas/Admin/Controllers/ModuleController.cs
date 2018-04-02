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
        userAuthorized user = WebConfig.GetUser();
        //
        // GET: /Admin/Report/
        [HttpGet]
        public ActionResult Index()
        {
            ModuleModel model = new ModuleModel();
            var moduleName = Request.Params["_module"];
            if (!string.IsNullOrEmpty(moduleName))
            {
                model.module = bll.GetModule(moduleName).FirstOrDefault();
                model.actions = bll.GetModuleActions(moduleCode: moduleName);
                model.columns = bll.GetModuleActionsColumns(moduleCode: moduleName);
                model.query = bll.GetModuleActionsQuery(moduleCode: moduleName);
                return View(model);
            }
            return Redirect("Error/In404");
        }

        [HttpGet]
        public JsonResult ActionGet(int pageSize, int pageIndex, string _module, string _action)
        {
            var dis = GetPostParams(new string[] { "pageSize", "pageIndex", "_module", "_action" });
            var res = bll.Query(pageSize, pageIndex, _module, _action, user.userId, dis);
            //return new JsonResult() { Data = new { total = res.Count(), rows = res }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return base.NewtonsoftJson(new { total = res.Count(), rows = res }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ActionPost(string _module, string _action)
        {
            var dis = GetPostParams(new string[] { "_module", "_action" });
            bll.ActionPost(_module, _action, user.userId, dis);
            return base.NewtonsoftJson(new { Status = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取Post过来的参数
        /// </summary>
        /// <param name="excludeParams"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetPostParams(string[] excludeParams = null)
        {
            Dictionary<string, string> dis = new Dictionary<string, string>();
            foreach (var item in Request.QueryString.AllKeys)
            {
                if (excludeParams == null || !excludeParams.Contains(Request.QueryString[item]))
                    dis.Add(item, Request.QueryString[item]);
            }
            return dis;
        }

    }
}
