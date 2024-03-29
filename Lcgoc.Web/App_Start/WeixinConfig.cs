﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lcgoc.Weixin.SDK.Helpers;

namespace Lcgoc.Web
{
    public class WeixinConfig
    {
        /// <summary>
        /// 微信Token
        /// </summary>
        public static string Token { private set; get; }
        /// <summary>
        /// 微信消息体加密对应的EncodingAESKey
        /// </summary>
        public static string EncodingAESKey { private set; get; }
        /// <summary>
        /// 微信AppId
        /// </summary>
        public static string AppID { private set; get; }
        /// <summary>
        /// 微信AppSecret
        /// </summary>
        public static string AppSecret { private set; get; }
        /// <summary>
        /// 用于微信支付的PartnerKey
        /// </summary>
        public static string PartnerKey { private set; get; }
        /// <summary>
        /// 用于微信支付的商户号
        /// </summary>
        public static string mch_id { private set; get; }
        /// <summary>
        /// 用于微信支付的设备号
        /// </summary>
        public static string device_info { private set; get; }
        /// <summary>
        /// 用于微信支付的服务端
        /// </summary>
        public static string spbill_create_ip { private set; get; }

        public static TokenHelper TokenHelper { private set; get; }

        public static void Register()
        {

            Token = System.Configuration.ConfigurationManager.AppSettings["Token"];
            EncodingAESKey = System.Configuration.ConfigurationManager.AppSettings["EncodingAESKey"];
            AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"];
            AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"];
            PartnerKey = System.Configuration.ConfigurationManager.AppSettings["PartnerKey"];
            mch_id = System.Configuration.ConfigurationManager.AppSettings["mch_id"];
            device_info = System.Configuration.ConfigurationManager.AppSettings["device_info"];
            spbill_create_ip = System.Configuration.ConfigurationManager.AppSettings["spbill_create_ip"];
            var openJSSDK = int.Parse(System.Configuration.ConfigurationManager.AppSettings["OpenJSSDK"]) > 0;
            TokenHelper = new TokenHelper(6000, AppID, AppSecret, openJSSDK);
            TokenHelper.Run();
        }
    }
}