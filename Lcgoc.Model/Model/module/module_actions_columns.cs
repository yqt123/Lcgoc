using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class module_actions_columns
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
        /// 列编码
        /// </summary>
        public string columnCode { get; set; }
        /// <summary>
        /// 列名称
        /// </summary>
        public string columnName { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool allowused { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string modifyDTM { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int level { get; set; }
        public bool keyword { get; set; }
        public string @typeof { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string glyphicon { get; set; }
    }
}
