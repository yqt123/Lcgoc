using Dapper;
using Lcgoc.Common;
using Lcgoc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lcgoc.DAL
{
    public class ApiControllerDAL
    {
        /// <summary>
        /// 根据编号找控制器
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<api_Controller> GetApiControllerByCode(string code)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT * from api_Controller where `code`=@code and allowUsed=1;";
                var myparams = new DynamicParameters(new { code = code });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {
                    return grids.Read<api_Controller>();
                }
            }
        }

        /// <summary>
        /// 查找所有控制器
        /// </summary>
        /// <returns></returns>
        public IEnumerable<api_Controller> GetApiController()
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = "SELECT * from api_Controller where allowUsed=1;";
                using (var grids = connection.QueryMultiple(spsql))
                {
                    return grids.Read<api_Controller>();
                }
            }
        }

        /// <summary>
        /// 写控制器日志
        /// </summary>
        /// <returns></returns>
        public bool WriteApiControllerLog(api_controller_log log)
        {
            using (IDbConnection connection = new MyConnectionHelper().connectionGetAndOpen())
            {
                string spsql = @"
INSERT INTO api_controller_log(`code`,`request`,`response`,`startTime`,`endTime`,`state`)
VALUES(@code,@request,@response,@startTime,@endTime,@state);
";
                var myparams = new DynamicParameters(new { code = log.code, request = log.request, response = log.response, startTime = log.startTime, endTime = log.endTime, state = log.state });
                using (var grids = connection.QueryMultiple(spsql, myparams))
                {

                }
            }
            return true;
        }

    }
}
