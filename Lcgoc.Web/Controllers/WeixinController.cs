using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Lcgoc.Weixin.SDK;
using System.Xml;
using Tencent;
using Lcgoc.Web.Services;
using Lcgoc.BLL;
using Lcgoc.Model;
using System.Threading;

namespace Lcgoc.Web.Controllers
{
    public class WeixinController : Controller
    {
        public WeixinController()
        {

        }

        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            var token = WeixinConfig.Token;//微信公众平台后台设置的Token
            if (string.IsNullOrEmpty(token)) return Content("请先设置Token！");
            var ent = "";
            if (!BasicAPI.CheckSignature(signature, timestamp, nonce, token, out ent))
            {
                return Content("参数错误！");
            }
            return Content(echostr); //返回随机字符串则表示验证通过
        }

        /// <summary>
        /// 用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// </summary>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(string signature, string timestamp, string nonce, string echostr)
        {
            WeixinMessage message = null;
            var safeMode = Request.QueryString.Get("encrypt_type") == "aes";
            var openid = Request.QueryString.Get("openid");
            var decryptMsg = string.Empty;
            var guid = Guid.NewGuid().ToString("N");
            WeixinLogBLL bll = new WeixinLogBLL();
            //检查微信加密签名
            var ent = "";
            if (!BasicAPI.CheckSignature(signature, timestamp, nonce, WeixinConfig.Token, out ent))
            {
                return Content("参数错误！");
            }
            using (var streamReader = new StreamReader(Request.InputStream))
            {
                var msg = streamReader.ReadToEnd();
                var msg_signature = string.Empty;
                var res = string.Empty;
                #region 解密
                if (safeMode)
                {
                    msg_signature = Request.QueryString.Get("msg_signature");
                    var wxBizMsgCrypt = new WXBizMsgCrypt(WeixinConfig.Token, WeixinConfig.EncodingAESKey, WeixinConfig.AppID);
                    var ret = wxBizMsgCrypt.DecryptMsg(msg_signature, timestamp, nonce, msg, ref decryptMsg);
                    if (ret != 0)//解密失败
                    {
                        //TODO：开发者解密失败的业务处理逻辑
                        //注意：本demo用log4net记录此信息，你可以用其他方法
                        //LogWriter.Default.WriteError(string.Format("decrypt message return {0}, request body {1}", ret, msg));
                        res = "解密失败";
                    }
                }
                else
                {
                    decryptMsg = msg;
                }
                #endregion
                //写数据库日志
                if (Lcgoc.Common.ConfigHelper.GetConfigString("dblog") == "1")
                    new Thread((ThreadStart)delegate { bll.WriteWeixinControllerLog(new crm_weixin_controller_log() { guid = guid, msg = msg, msg_signature = msg_signature, nonce = nonce, signature = signature, openid = openid, timestamp = timestamp, url = Request.Url.ToString(), res = res }); }).Start();
                message = AcceptMessageAPI.Parse(decryptMsg);
            }
            var response = new WeixinExecutor().Execute(message, decryptMsg, guid);
            var encryptMsg = string.Empty;

            #region 加密
            if (safeMode)
            {
                var msg_signature = Request.QueryString.Get("msg_signature");
                var wxBizMsgCrypt = new WXBizMsgCrypt(WeixinConfig.Token, WeixinConfig.EncodingAESKey, WeixinConfig.AppID);
                var ret = wxBizMsgCrypt.EncryptMsg(response, timestamp, nonce, ref encryptMsg);
                if (ret != 0)//加密失败
                {
                    //TODO：开发者加密失败的业务处理逻辑
                    LogWriter.Default.WriteError(string.Format("encrypt message return {0}, response body {1}", ret, response));
                }
            }
            else
            {
                encryptMsg = response;
            }
            #endregion

            return new ContentResult
            {
                Content = encryptMsg,
                ContentType = "text/xml",
                ContentEncoding = System.Text.UTF8Encoding.UTF8
            };
        }

    }
}
