using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class admin_menu_detail
    {
        public string code { get; set; }
        public string sequence { get; set; }        
        public string name { get; set; }
        public string controller { get; set; }
        public string action { get; set; }
        public int ajaxlink { get; set; }
        public int allowused { get; set; }
        public DateTime modifyDTM { get; set; }
        public int level { get; set; }
    }
}
