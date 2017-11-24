using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class user
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nick { get; set; }
        public string sex { get; set; }
        public string realName { get; set; }
        public string birthday { get; set; }
        public string image { get; set; }
        public string registerTime { get; set; }
        public string lastLoginTime { get; set; }
        public DateTime modifyDTM { get; set; }
        public int allowused { get; set; }
    }
}
