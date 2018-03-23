using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;

namespace Lcgoc.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController : Controller
    {
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
