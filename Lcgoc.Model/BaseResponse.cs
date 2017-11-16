using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lcgoc.Model
{
    /// <summary>
    /// 数据请求基类
    /// </summary>
    public class BaseResponse<T> : AbsResponse
        where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }
    }
}
