using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class module_queue
    {
        /// <summary>
        /// 队列编号
        /// </summary>
        public string queueCode { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string describe { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool allowused { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string modifyDTM { get; set; }
        /// <summary>
        /// 模块编码
        /// </summary>
        public string moduleCode { get; set; }
        /// <summary>
        /// 执行编码
        /// </summary>
        public string actionCode { get; set; }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string userId { get; set; }
    }
}
