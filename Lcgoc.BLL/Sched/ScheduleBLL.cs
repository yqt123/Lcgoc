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
        public IEnumerable<ScheduleJob_Details> QueryScheduleDetails(string schedName = "", string jobName = "")
        {
            return dal.QueryScheduleDetails(schedName, jobName);
        }
        public bool ScheduleDetailsDelete(int id)
        {
            return dal.ScheduleDetailsDelete(id);
        }
        public bool ScheduleDetailsAdd(ScheduleJob_Details data)
        {
            return dal.ScheduleDetailsAdd(data);
        }
        public bool ScheduleDetailsEdit(ScheduleJob_Details data)
        {
            return dal.ScheduleDetailsEdit(data);
        }

        public IEnumerable<ScheduleJob_Details_Triggers> QueryScheduleDetailsTriggers(string schedName = "", string jobName = "")
        {
            return dal.QueryScheduleDetailsTriggers(schedName, jobName);
        }
        public bool ScheduleDetailsTriggersDelete(int id)
        {
            return dal.ScheduleDetailsTriggersDelete(id);
        }
        public bool ScheduleDetailsTriggersAdd(ScheduleJob_Details_Triggers data)
        {
            return dal.ScheduleDetailsTriggersAdd(data);
        }
        public bool ScheduleDetailsTriggersEdit(ScheduleJob_Details_Triggers data)
        {
            return dal.ScheduleDetailsTriggersEdit(data);
        }

    }
}
