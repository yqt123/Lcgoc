using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class module_actions_query
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        public string moduleCode { get; set; }
        /// <summary>
        /// 执行编码
        /// </summary>
        public string actionCode { get; set; }
        /// <summary>
        /// 查询编码
        /// </summary>
        public string queryCode { get; set; }
        /// <summary>
        /// 查询名称
        /// </summary>
        public string queryName { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool allowused { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string modifyDTM { get; set; }
    }
}
