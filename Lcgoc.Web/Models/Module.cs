using Lcgoc.Model;
using System.Collections.Generic;

namespace Lcgoc.Web.Models
{
    public class ModuleModel
    {
        public module module { get; set; }
        public IEnumerable<module_actions> actions { get; set; }
        public IEnumerable<module_actions_query> query { get; set; }
        public IEnumerable<module_actions_columns> columns { get; set; }
    }
}