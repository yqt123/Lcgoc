﻿using Lcgoc.BLL;
using Lcgoc.Model;
using Lcgoc.Web.Areas.Admin.Filters;
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
    [ControlRight]
    public class MenuController : Controller
    {
        //
        // GET: /Admin/Report/
        [HttpGet]
        public PartialViewResult Index()
        {
            return PartialView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="rightMessage">权限控制时返回的提示</param>
        /// <returns></returns>
        [HttpPost]
        //防止了跨站攻击
        [ValidateAntiForgeryToken]
        public JsonResult Create(admin_menu model, string rightMessage)
        {
            BaseResponse<string> res = new BaseResponse<string>();
            if (ModelState.IsValid && new AdminMenuBLL().CreateMenu(model))
            {
                res.Code = ResponseCodeEnum.Success;
            }
            else
            {
                res.Code = ResponseCodeEnum.Fail;
                res.Error = "保存失败！";
            }
            return new JsonResult() { Data = res, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        //防止了跨站攻击
        [ValidateAntiForgeryToken]
        public JsonResult Delete(admin_menu model, string rightMessage)
        {
            if (ModelState.IsValid)
            {

            }
            ModelState.AddModelError("", "保存失败！");
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
