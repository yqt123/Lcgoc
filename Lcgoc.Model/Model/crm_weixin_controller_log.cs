using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class crm_weixin_controller_log
    {
        public string guid { get; set; }
        public string signature { get; set; }
        public string timestamp { get; set; }
        public string nonce { get; set; }
        public string openid { get; set; }
        public string url { get; set; }
        public string msg_signature { get; set; }
        public string msg { get; set; }
        public string res { get; set; }
    }
}
