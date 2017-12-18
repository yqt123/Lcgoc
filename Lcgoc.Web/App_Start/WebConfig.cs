using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lcgoc.Weixin.SDK.Helpers;
using Lcgoc.Common;

namespace Lcgoc.Web
{
    /// <summary>
    /// 获取Web.config的配置数据
    /// </summary>
    public class WebConfig
    {
        #region 静态数据
        /// <summary>
        /// 平台名称
        /// </summary>
        public static string AdminName { private set; get; }

        /// <summary>
        /// 是否开启权限控制
        /// </summary>
        public static bool OpenRightControl { private set; get; }

        /// <summary>
        /// 登录系统的Session名称
        /// </summary>
        public static string LoginSessionName { private set; get; }

        /// <summary>
        /// 登录系统的Session名称
        /// </summary>
        public static string LoginTokenName { private set; get; }

        /// <summary>
        /// 登录系统，记住密码时有效天数
        /// </summary>
        public static int ExpiresDays { private set; get; }

        #endregion

        #region 动态数据
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public static Lcgoc.Model.userAuthorized GetUser()
        {
            var entity = System.Web.HttpContext.Current.Session[WebConfig.LoginSessionName];
            if (entity != null)
                return entity as Lcgoc.Model.userAuthorized;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[WebConfig.LoginTokenName];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                var identityData = new Lcgoc.BLL.UserBLL().GetLoginAuthorizedByToken(cookie.Value);
                if (identityData != null)
                {
                    System.Web.HttpContext.Current.Session[WebConfig.LoginSessionName] = identityData;
                    System.Web.HttpContext.Current.Session.Timeout = 30;
                    return identityData;
                }
            }
            return null;
        }

        #endregion

        /// <summary>
        /// 注册数据
        /// </summary>
        public static void Register()
        {
            AdminName = System.Configuration.ConfigurationManager.AppSettings["AdminName"];
            LoginSessionName = System.Configuration.ConfigurationManager.AppSettings["LoginSessionName"];

            bool _OpenRightControl = false;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["OpenRightControl"], out _OpenRightControl);
            OpenRightControl = _OpenRightControl;

            LoginTokenName = System.Configuration.ConfigurationManager.AppSettings["LoginTokenName"];

            int _ExpiresDays = 0;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["ExpiresDays"], out _ExpiresDays);
            ExpiresDays = _ExpiresDays;
        }
    }
}