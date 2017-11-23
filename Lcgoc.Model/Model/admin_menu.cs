using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class admin_menu
    {
        public string code { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int allowused { get; set; }
        public DateTime modifyDTM { get; set; }
        public int level { get; set; }
        public string pullRightContainer { get; set; }
    }
}
