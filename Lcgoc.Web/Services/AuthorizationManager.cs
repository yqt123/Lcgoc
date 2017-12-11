using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lcgoc.BLL;
using Lcgoc.Model;

namespace Lcgoc.Web.Services
{
    public class AuthorizationManager
    {
        public static void SetTicket(bool remeberMe, int version, string identity, string displayName)
        {
            FormsAuthentication.SetAuthCookie(identity, remeberMe);
            if (string.IsNullOrEmpty(displayName))//displayName为空会导致cookies写入失败
            {
                displayName = "匿名";
            }
            var authTicket = new FormsAuthenticationTicket(
                version,
                identity,
                DateTime.Now,
                DateTime.Now.AddDays(remeberMe ? 30 : 1),
                remeberMe,
                displayName);
            string encrytedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrytedTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        /// <summary>
        /// 设置后台管理平台的登录凭证，考虑到一个系统可能多个登录的情况，没有使用框架自带的FormsAuthentication认证（微信平台已经使用）
        /// </summary>
        /// <param name="remeberMe"></param>
        /// <param name="identity"></param>
        public static void SetAdminTicket(bool remeberMe, string identity)
        {
            System.Web.HttpContext.Current.Session[WebConfig.LoginSessionName] = identity;
            System.Web.HttpContext.Current.Session.Timeout = 30;
            //如果记住密码，用cookie记住token
            if (remeberMe)
            {
                string token = identity + Math.Abs(DateTime.Now.ToBinary()).ToString();
                new UserBLL().RefreshLoginToken(new crm_loginToken_log { identity = identity, userAgent = HttpContext.Current.Request.UserAgent, token = token }, WebConfig.ExpiresDays);

                HttpCookie cookie = new HttpCookie(WebConfig.LoginTokenName);//初使化并设置Cookie的名称
                cookie.Expires = DateTime.Now.AddDays(WebConfig.ExpiresDays);
                cookie.Value = token;
                cookie.Path = "/";
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

    }
}