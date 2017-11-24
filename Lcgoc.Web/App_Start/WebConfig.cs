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
        /// <summary>
        /// 平台名称
        /// </summary>
        public static string AdminName { private set; get; }

        /// <summary>
        /// 是否开启权限控制
        /// </summary>
        public static bool OpenRightControl { private set; get; }

        public static void Register()
        {
            AdminName = System.Configuration.ConfigurationManager.AppSettings["AdminName"];

            bool _OpenRightControl = false;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["OpenRightControl"], out _OpenRightControl);
            OpenRightControl = _OpenRightControl;
        }
    }
}