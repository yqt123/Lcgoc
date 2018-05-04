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
        public bool ScheduleDelete(int id)
        {
            return dal.ScheduleDelete(id);
        }
        public bool ScheduleAdd(ScheduleJob data)
        {
            return dal.ScheduleAdd(data);
        }
        public bool ScheduleEdit(ScheduleJob data)
        {
            return dal.ScheduleEdit(data);
        }

        public IEnumerable<ScheduleJob_Details> QueryScheduleDetails(string schedName = "", string jobName = "")
        {
            return dal.QueryScheduleDetails(schedName, jobName);
        }
        public IEnumerable<ScheduleJob_Details_Triggers> QueryScheduleDetailsTriggers(string schedName = "", string jobName = "")
        {
            return dal.QueryScheduleDetailsTriggers(schedName, jobName);
        }
    }
}
