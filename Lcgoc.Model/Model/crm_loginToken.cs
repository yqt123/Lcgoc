using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class crm_loginToken
    {
        public string identity { get; set; }
        public string token { get; set; }
        public string createDate { get; set; }
        public int ExpiresDays { get; set; }
        public DateTime modifyDTM { get; set; }
    }
}
