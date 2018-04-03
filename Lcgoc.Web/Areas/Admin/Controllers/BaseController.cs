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
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取Post和Get过来的参数
        /// </summary>
        /// <returns></returns>
        protected Dictionary<string, string> GetFormOrQueryStringParams()
        {
            Dictionary<string, string> dis = new Dictionary<string, string>();
            foreach (var item in Request.QueryString.AllKeys)
            {
                dis.Add(item, Request.QueryString[item]);
            }
            foreach (var item in Request.Form.AllKeys)
            {
                dis.Add(item, Request.Form[item]);
            }
            return dis;
        }

        /// <summary>
        /// 筛选参数
        /// </summary>
        /// <param name="excludeParams"></param>
        /// <returns></returns>
        protected Dictionary<string, string> SizerPostParams(string[] excludeParams = null)
        {
            var _params = GetFormOrQueryStringParams();
            if (excludeParams == null || excludeParams.Length == 0) return _params;
            Dictionary<string, string> dis = new Dictionary<string, string>();
            foreach (var item in _params)
            {
                if (!excludeParams.Contains(item.Key))
                    dis.Add(item.Key, item.Value);
            }
            return dis;
        }

        protected JsonResult NewtonsoftJson(object data, JsonRequestBehavior behavior)
        {
            return new NewtonsoftJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
            };
        }
    }

    /// <summary>
    /// Newtonsoft序列化方式
    /// </summary>
    public class NewtonsoftJsonResult : JsonResult
    {
        /// <summary>
        /// 重写执行视图
        /// </summary>
        /// <param name="context">上下文</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                var jsonString = JsonConvert.SerializeObject(this.Data);
                response.Write(jsonString);
            }
        }
    }
}
