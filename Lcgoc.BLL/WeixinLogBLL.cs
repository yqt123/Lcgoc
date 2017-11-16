using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;

namespace Lcgoc.BLL
{
    public class WeixinLogBLL
    {
        WeixinLogDAL dal = new WeixinLogDAL();
        public bool WriteWeixinLog(crm_weixin_log log)
        {
            return dal.WriteWeixinLog(log);
        }

        public bool WriteWeixinControllerLog(crm_weixin_controller_log log)
        {
            return dal.WriteWeixinControllerLog(log);
        }
    }
}
