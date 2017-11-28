using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lcgoc.Model;
using Lcgoc.DAL;
using Lcgoc.Common;

namespace Lcgoc.BLL
{
    public class HomeApiBLL
    {
        ApiControllerDAL dal = new ApiControllerDAL();
        public AbsResponse Execute(dynamic request, string requestStr)
        {
            api_controller_log log = new api_controller_log() { code = request.code, startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), state = true, request = requestStr };
            try
            {
                var controllers = dal.GetApiControllerByCode(log.code);
                if (controllers == null || controllers.Count() == 0)
                {
                    throw new Exception("没有该接口编码！");
                }
                var controller = controllers.FirstOrDefault();
                Assembly outerAsm = Assembly.LoadFrom(System.AppDomain.CurrentDomain.BaseDirectory + @"bin/" + controller.dll);
                Type objType = outerAsm.GetType(controller.fullClass, false);
                if (objType == null)
                {
                    throw new Exception("接口编码配置错误，请找相关人员进行处理！");
                }
                var APIBase = (AbsApi)Activator.CreateInstance(objType);
                APIBase.requestModel = request.ResquestModel;
                return APIBase.Execute();
            }
            catch (Exception ex)
            {
                log.state = false;
                log.response = ex.Message;
                return new BaseResponse<string> { State = false, Code = ResponseCodeEnum.Fail, Error = ex.Message };
            }
            finally
            {
                log.endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                dal.WriteApiControllerLog(log);
            }
        }
    }
}
