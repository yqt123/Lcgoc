using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lcgoc.Model;

namespace Lcgoc.DAL
{
    public class TestDAL : AbsApi
    {
        /// <summary>
        /// 执行接口
        /// </summary>
        public override AbsResponse Execute()
        {
            var request = this.requestModel;
            return new BaseResponse { Status = true, Result = request };
        }
    }
}
