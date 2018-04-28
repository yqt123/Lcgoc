using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lcgoc.Model;
using Lcgoc.DAL;

namespace Lcgoc.BLL
{
    public class ScheduleBLL
    {
        ScheduleDAL dal = new ScheduleDAL();
        public IEnumerable<ScheduleJob> QuerySchedule(string schedName = "", string jobName = "")
        {
            return dal.QuerySchedule(schedName, jobName);
        }
    }
}
