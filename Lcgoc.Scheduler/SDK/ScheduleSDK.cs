using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Lcgoc.Model;
using NLog;
using System.ComponentModel;

namespace Lcgoc.Scheduler
{
    public class ScheduleSDK
    {
        /// <summary>
        /// 采集日志
        /// </summary>
        /// <param name="scheduleLog"></param>
        public void WirteScheduleLog(WriteScheduleJob_Log scheduleLog)
        {
            //BaseResquest<WriteScheduleJob_Log, BaseResponse<string>> request = new BaseResquest<WriteScheduleJob_Log, BaseResponse<string>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.WriteScheduleJob_LogDAL",
            //    ResquestModel = scheduleLog
            //};
            //var result = request.HttpPost();
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public string GetServiceTime()
        {
            //BaseResquest<string, BaseResponse<string>> request = new BaseResquest<string, BaseResponse<string>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.GetServiceTimeDAL"
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        /// <summary>
        /// 查找作业
        /// </summary>
        /// <param name="schedName"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public List<ScheduleJob> QuerySchedule(string schedName = "", string jobName = "")
        {
            if (SysParams.FromXML)
            {
                return new ScheduleXML().QuerySchedule(schedName, jobName);
            }
            //BaseResquest<QuerySchedule, BaseResponse<List<ScheduleJob>>> request = new BaseResquest<QuerySchedule, BaseResponse<List<ScheduleJob>>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.QueryScheduleDAL",
            //    ResquestModel = new QuerySchedule { job_name = jobName, sched_name = schedName }
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        /// <summary>
        /// 根据作业名查找job
        /// </summary>
        /// <param name="schedName"></param>
        /// <returns></returns>
        public List<ScheduleJob_Details> QueryJobDetails(string schedName = "", string jobName = "")
        {
            if (SysParams.FromXML)
            {
                return new ScheduleXML().QueryJobDetails(schedName, jobName);
            }
            //BaseResquest<QuerySchedule, BaseResponse<List<ScheduleJob_Details>>> request = new BaseResquest<QuerySchedule, BaseResponse<List<ScheduleJob_Details>>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.QueryJobDetailsDAL",
            //    ResquestModel = new QuerySchedule { job_name = jobName, sched_name = schedName }
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        public IEnumerable<ScheduleJob_Details_Triggers> QueryTriggers(string schedName, string jobName)
        {
            if (SysParams.FromXML)
            {
                return new ScheduleXML().QueryTriggers(schedName, jobName);
            }
            //BaseResquest<QuerySchedule, BaseResponse<List<ScheduleJob_Details_Triggers>>> request = new BaseResquest<QuerySchedule, BaseResponse<List<ScheduleJob_Details_Triggers>>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.QueryTriggersDAL",
            //    ResquestModel = new QuerySchedule { job_name = jobName, sched_name = schedName }
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        public string ClearScheduleJobSaveLog(string schedName, string jobName, int days)
        {
            //BaseResquest<ClearScheduleJob, BaseResponse<string>> request = new BaseResquest<ClearScheduleJob, BaseResponse<string>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.ClearScheduleJobSaveLogDAL",
            //    ResquestModel = new ClearScheduleJob { job_name = jobName, sched_name = schedName, days = days.ToString() }
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        public string ClearScheduleJobApiLog(string schedName, string jobName, int days)
        {
            //BaseResquest<ClearScheduleJob, BaseResponse<string>> request = new BaseResquest<ClearScheduleJob, BaseResponse<string>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.ClearScheduleJobApiLogDAL",
            //    ResquestModel = new ClearScheduleJob { job_name = jobName, sched_name = schedName, days = days.ToString() }
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        /// <summary>
        /// 最后一次执行成功的时间
        /// </summary>
        /// <param name="schedName"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public string LastSuccessTimeDAL(string schedName, string jobName)
        {
            //BaseResquest<QuerySchedule, BaseResponse<string>> request = new BaseResquest<QuerySchedule, BaseResponse<string>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.LastSuccessTimeDAL",
            //    ResquestModel = new QuerySchedule { job_name = jobName, sched_name = schedName }
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        /// <summary>
        /// 获取推送消息
        /// </summary>
        /// <returns></returns>
        public List<MessageSend> GetMessageSend(string schedName, string jobName)
        {
            //BaseResquest<string, BaseResponse<List<MessageSend>>> request = new BaseResquest<string, BaseResponse<List<MessageSend>>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.MessageSendDAL"
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        /// <summary>
        /// 修改推送消息状态
        /// </summary>
        /// <returns></returns>
        public string MessageSendDeal(List<MessageSend> messageSend)
        {
            //BaseResquest<List<MessageSend>, BaseResponse<string>> request = new BaseResquest<List<MessageSend>, BaseResponse<string>>()
            //{
            //    APIUrl = SysParams.APIUrl,
            //    DALDLL = "WebAPI.DAL.dll",
            //    FullClasssName = "WebAPI.DAL.MessageSendDealDAL",
            //    ResquestModel = messageSend
            //};
            //var result = request.HttpPost();
            //return result.Result;
            return null;
        }

        public bool SaveScheduleJob(BindingList<ScheduleJob> schedule)
        {
            if (SysParams.FromXML)
            {
                return new ScheduleXML().SaveScheduleJob(schedule);
            }

            throw new Exception("未实现该方法");
        }

        public bool SaveScheduleDetail(BindingList<ScheduleJob_Details> scheduleDetail)
        {
            if (SysParams.FromXML)
            {
                return new ScheduleXML().SaveScheduleDetail(scheduleDetail);
            }

            throw new Exception("未实现该方法");
        }

        public bool SaveScheduleTriggers(BindingList<ScheduleJob_Details_Triggers> scheduleTriggers)
        {
            if (SysParams.FromXML)
            {
                return new ScheduleXML().SaveScheduleTriggers(scheduleTriggers);
            }

            throw new Exception("未实现该方法");
        }
    }
}
