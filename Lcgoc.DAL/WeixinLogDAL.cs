using Dapper;
using Lcgoc.Common;
using Lcgoc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lcgoc.DAL
{
    public class WeixinLogDAL
    {
        /// <summary>
        /// 微信操作日志
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool WriteWeixinLog(crm_weixin_log log)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = @"
INSERT INTO crm_weixin_log(`guid`,`openId`,`myUserName`,`domain`,`Type`,`request`,`response`,`startTime`,`endTime`,`eventKey`)
VALUES(@guid,@openId,@myUserName,@domain,@Type,@request,@response,@startTime,@endTime,@eventKey);";
                var myparams = new DynamicParameters(new { guid = log.guid, openId = log.openId, myUserName = log.myUserName, domain = log.domain, Type = log.Type, request = log.request, response = log.response, startTime = log.startTime, endTime = log.endTime, eventKey = log.eventKey });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {

                }
            }
            return true;
        }

        /// <summary>
        /// 微信请求日志
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool WriteWeixinControllerLog(crm_weixin_controller_log log)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = @"
INSERT INTO crm_weixin_controller_log(`guid`,`signature`,`timestamp`,`nonce`,`openid`,`url`,`msg_signature`,`msg`,`res`)
VALUES(@guid,@signature,@timestamp,@nonce,@openid,@url,@msg_signature,@msg,@res);";
                var myparams = new DynamicParameters(new { guid = log.guid, signature = log.signature, timestamp = log.timestamp, nonce = log.nonce, openid = log.openid, url = log.url, msg_signature = log.msg_signature, msg = log.msg, res = log.res });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {

                }
            }
            return true;
        }

    }
}
