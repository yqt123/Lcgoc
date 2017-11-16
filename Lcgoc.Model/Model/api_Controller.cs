using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class api_Controller
    {
        public string code { get; set; }
        public string describe { get; set; }
        public string dll { get; set; }
        public string fullClass { get; set; }
        public bool allowUsed { get; set; }
        public DateTime modifyDTM { get; set; }
    }
}
