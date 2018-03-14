using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class module_actions
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        public string moduleCode { get; set; }
        /// <summary>
        /// 操作编码
        /// </summary>
        public string actionCode { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string actionName { get; set; }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        public string exeProcedure { get; set; }
        /// <summary>
        /// 按钮字体图标
        /// </summary>
        public string glyphicon { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool allowused { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string modifyDTM { get; set; }
        /// <summary>
        /// 执行查询的表
        /// </summary>
        public string exeTableName { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sorting { get; set; }

        public bool dialog { get; set; }
    }
}
