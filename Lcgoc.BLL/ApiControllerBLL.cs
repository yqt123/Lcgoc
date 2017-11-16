using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;

namespace Lcgoc.BLL
{
    public class ApiControllerBLL
    {
        ApiControllerDAL dal = new ApiControllerDAL();
        public IEnumerable<api_Controller> GetApiControllerByCode(string code)
        {
            return dal.GetApiControllerByCode(code);
        }

        public IEnumerable<api_Controller> GetApiController()
        {
            return dal.GetApiController();
        }

        public bool WriteApiControllerLog(api_controller_log log)
        {
            return dal.WriteApiControllerLog(log);
        }
    }
}
