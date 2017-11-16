using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lcgoc.Model;

namespace Lcgoc.Model
{
    public abstract class AbsApi
    {
        /// <summary>
        /// 对象参数，如文件
        /// </summary>
        public object objArgs { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        public dynamic requestModel { get; set; }
        
        /// <summary>
        /// 执行接口
        /// </summary>
        public abstract AbsResponse Execute();
    }
}
