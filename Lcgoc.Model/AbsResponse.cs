using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcgoc.Model
{
    /// <summary>
    /// 数据返回基类
    /// </summary>
    public abstract class AbsResponse
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNo { get; set; }
    }
}
