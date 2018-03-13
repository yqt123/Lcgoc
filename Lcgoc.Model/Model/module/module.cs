using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lcgoc.Model
{
    public class module
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        public string moduleCode { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string moduleName { get; set; }
        /// <summary>
        /// 查询接口
        /// </summary>
        public string queryApiUrl { get; set; }
        /// <summary>
        /// 最小显示列表数
        /// </summary>
        public string minimumCountColumns { get; set; }
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
