using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class api_controller_log
    {
        public string code { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public bool state { get; set; }
    }
}
