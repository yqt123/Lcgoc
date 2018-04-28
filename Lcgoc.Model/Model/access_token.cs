using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class access_token
    {
        public string appId { get; set; }
        public string appSecret { get; set; }
        public string token { get; set; }
        public int expiresIn { get; set; }
        public string modifyDTM { get; set; }
    }
}