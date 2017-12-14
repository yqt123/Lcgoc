using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class sys_controller_action_role
    {
        public string controller { get; set; }
        public string action { get; set; }
        public string roleId { get; set; }
        public int allowused { get; set; }
        public DateTime modifyDTM { get; set; }
    }
}
