using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Lcgoc.BLL;
using Codeplex.Data;
using Lcgoc.Model;

namespace Lcgoc.Web.Controllers
{
    //public class HomeApiController : ApiController
    //{
    //    /// <summary>
    //    /// 接口统一入口
    //    /// </summary>
    //    /// <returns></returns>
    //    public HttpResponseMessage Index()
    //    {
    //        var argStr = GetPostArgs();
    //        //TODO 处理解密过程
    //        HomeApiBLL api = new HomeApiBLL();
    //        var ret = api.Execute(DynamicJson.Parse(argStr), argStr);
    //        //TODO 处理加密过程
    //        return new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(ret), System.Text.Encoding.GetEncoding("UTF-8"), "application/json") };
    //    }

    //    #region 私有方法

    //    /// <summary>
    //    /// 获取传递过来的参数
    //    /// </summary>
    //    /// <param name="ParamsName"></param>
    //    /// <returns></returns>
    //    private string GetPostArgs()
    //    {
    //        if (HttpContext.Current.Request.InputStream.Length == 0)
    //            return "";
    //        if (HttpContext.Current.Request.ContentType.Contains("multipart/form-data"))
    //        {
    //            string args = string.Empty;
    //            if (HttpContext.Current.Request.Form["formJson"] != null)
    //            {
    //                args = HttpContext.Current.Request.Form["formJson"].ToString();
    //            }
    //            else
    //            {
    //                args = "{";
    //                for (int n = 0; n < HttpContext.Current.Request.Form.Count; n++)
    //                {
    //                    string name = HttpContext.Current.Request.Form.Keys[n].ToString();
    //                    string value = "'" + HttpContext.Current.Request.Form[n].ToString() + "'";
    //                    if (name == "ResquestModel" && !string.IsNullOrEmpty(HttpContext.Current.Request.Form[n].ToString()))
    //                    {
    //                        value = HttpContext.Current.Request.Form[n].ToString();
    //                    }
    //                    if (n == HttpContext.Current.Request.Form.Count - 1)
    //                        args += string.Format("'{0}':{1}", name, value);
    //                    else
    //                        args += string.Format("'{0}':{1},", name, value);
    //                }
    //                args += "}";
    //            }
    //            return args;
    //        }
    //        byte[] byts = new byte[HttpContext.Current.Request.InputStream.Length];
    //        HttpContext.Current.Request.InputStream.Read(byts, 0, byts.Length);
    //        return System.Text.Encoding.UTF8.GetString(byts);
    //    }

    //    #endregion
    //}
}
