using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class admin_menu_detail_right
    {
        public string userId { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public string allowused { get; set; }
        public DateTime modifyDTM { get; set; }
    }
}
