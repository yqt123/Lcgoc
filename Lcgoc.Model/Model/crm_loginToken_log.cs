using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class crm_loginToken_log
    {
        public string id { get; set; }
        public string identity { get; set; }
        public string userAgent { get; set; }
        public string ip { get; set; }
        public string token { get; set; }
        public DateTime modifyDTM { get; set; }
    }
}
