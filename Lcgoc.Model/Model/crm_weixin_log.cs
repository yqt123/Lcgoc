using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class crm_weixin_log
    {
        public string guid { get; set; }
        public string openId { get; set; }
        public string myUserName { get; set; }
        public string domain { get; set; }
        public string Type { get; set; }
        public string eventKey { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}
