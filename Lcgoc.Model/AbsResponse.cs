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
        public bool Status { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public ResponseCodeEnum Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNo { get; set; }
    }
}
