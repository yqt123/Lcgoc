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
        public IEnumerable<ScheduleJob_Details> ListScheduleDetails(string schedName = "", string jobName = "")
        {
            return dal.ListScheduleDetails(schedName, jobName);
        }
        public bool DeleteScheduleDetails(int id)
        {
            return dal.DeleteScheduleDetails(id);
        }
        public bool SaveScheduleDetails(ScheduleJob_Details data)
        {
            return dal.SaveScheduleDetails(data);
        }
        public bool EditScheduleDetails(ScheduleJob_Details data)
        {
            return dal.EditScheduleDetails(data);
        }
        public IEnumerable<ScheduleJob_Details_Triggers> ListScheduleDetailsTriggers(string schedName = "", string jobName = "")
        {
            return dal.ListScheduleDetailsTriggers(schedName, jobName);
        }
        public bool DeleteScheduleDetailsTriggers(int id)
        {
            return dal.DeleteScheduleDetailsTriggers(id);
        }
        public bool SaveScheduleDetailsTriggers(ScheduleJob_Details_Triggers data)
        {
            return dal.SaveScheduleDetailsTriggers(data);
        }
        public bool EditScheduleDetailsTriggers(ScheduleJob_Details_Triggers data)
        {
            return dal.EditScheduleDetailsTriggers(data);
        }
        public bool SaveScheduleLog(ScheduleJob_Log data)
        {
            return dal.SaveScheduleLog(data);
        }
        public IEnumerable<ScheduleJob_Log> ListScheduleLog()
        {
            return dal.ListScheduleLog();
        }
        public IEnumerable<ScheduleJob_Log> ListScheduleJobLog(DateTime startTime, DateTime endTime)
        {
            return dal.ListScheduleJobLog(startTime, endTime);
        }
        public bool DeleteScheduleJobLog(DateTime startTime, DateTime endTime)
        {
            return dal.DeleteScheduleJobLog(startTime, endTime);
        }
    }
}
