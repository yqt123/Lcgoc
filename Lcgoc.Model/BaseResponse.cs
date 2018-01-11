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
    public class BaseResponse : AbsResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public dynamic Result { get; set; }

        /// <summary>
        /// 设置返回状态
        /// </summary>
        public void SetStatus(bool status)
        {
            this.Status = status;
            this.Code = status ? ResponseCodeEnum.Success : ResponseCodeEnum.Fail;
            this.Message = status ? "操作成功" : "操作失败";
        }
    }
}
