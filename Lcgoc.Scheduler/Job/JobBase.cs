using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using NLog;
using Lcgoc.Model;
using Lcgoc.BLL;

namespace Lcgoc.Scheduler
{
    public class JobBase : IJob
    {
        #region 声明
        public static readonly string jobDetailMad = "jobDetail";
        public static readonly string triggerMad = "jobTrigger";
        public ScheduleJob_Details jobDetail { get; private set; }
        public IEnumerable<ScheduleJob_Details_Triggers> jobDetailTrigger { get; private set; }
        public ScheduleJob_Log ScheduleLog { get; private set; }
        public ScheduleJob ScheduleSet { get; private set; }
        public string JobName { get; set; }
        /// <summary>
        /// 本次执行查询截止时间
        /// </summary>
        public DateTime ExeEndQueryTime { get; set; }
        /// <summary>
        /// 在父类写日志
        /// </summary>
        public bool IsWriteScheduleJobLogAtParent { get; set; }

        ScheduleBLL schedulebll = new ScheduleBLL();
        #endregion
        /// <summary>
        /// IJob执行作业，使用context在子类和基类之间传值，执行成功或者失败的值由context从子类带回来
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                try
                {
                    ExeEndQueryTime = DateTime.Now;
                    IsWriteScheduleJobLogAtParent = true;
                    this.jobDetail = context.MergedJobDataMap[jobDetailMad] as ScheduleJob_Details;
                    this.jobDetailTrigger = context.MergedJobDataMap[triggerMad] as IEnumerable<ScheduleJob_Details_Triggers>;
                    if (this.jobDetail == null)
                    {
                        context.Put("ExecResult", "取不到作业计划");
                        throw new Exception(string.Format("【{0}】的[Execute]从[IJobExecutionContext]读取不到作业计划信息，本次执行失败！", this.JobName));
                    }
                    ScheduleSet = schedulebll.QuerySchedule(jobDetail.sched_name, jobDetail.job_name).FirstOrDefault();
                    if (ScheduleSet.writeTxtLog) SysParams.logger.Info(string.Format("【{0}】开始执行IJOB的[Execute]...", this.JobName));
                    //刷新作业计划信息，防止作业计划配置发生改变
                    ScheduleJob_Details jobDetailNew = schedulebll.QueryScheduleDetails(jobDetail.sched_name, jobDetail.job_name).FirstOrDefault(); //刷新作业计划信息
                    IEnumerable<ScheduleJob_Details_Triggers> jobDetailTriggerNew = schedulebll.QueryScheduleDetailsTriggers(jobDetail.sched_name, jobDetail.job_name);
                    //检查新查询出来的计划是否能执行
                    if (jobDetailNew == null || jobDetailTriggerNew == null || jobDetailTriggerNew.Count() == 0)
                    {
                        //计划已经被删除，则删除此作业
                        context.Scheduler.DeleteJob(context.JobDetail.Key);
                        context.Put("ExecResult", "完成");
                        throw new Exception(string.Format("【{0}】作业计划为空，该记录可能已经被删除。", this.jobDetail.sched_name));
                    }
                    //不从调度计划中删除本作业，因为有可能客户又启用该作业计划
                    if (!jobDetailNew.is_durable)
                    {
                        if (ScheduleSet.writeTxtLog) SysParams.logger.Info(string.Format("【{0}】作业计划不允许使用，跳过此次执行。", this.jobDetail.description));
                        context.Put("ExecResult", "完成");
                        return;
                    }
                    if (!jobDetailNew.scheEquals(jobDetail) || IsChangedTrigger(jobDetailTrigger, jobDetailTriggerNew))
                    {
                        //脏数据，删除此作业，然后重新创建一个
                        SysParams.logger.Info(string.Format("【{0}】的作业计划属性已更改，将删除该计划的实现作业，然后重新创建一个作业。", this.jobDetail.description));
                        context.Put("ExecResult", "重新创建一个作业");
                        //作业计划属性发生变更，重新启动作业
                        //Tuple<IJobDetail, List<ITrigger>> tuple = JobHelper.RestartJob(context.Scheduler, jobDetail, jobDetailNew);
                        //SysParams.logger.Info(string.Format("【{0}】的重新创建一个作业完毕，[IJOB.Execute]退出。作业计划：{1}，作业：{2}，触发器：{3}，表达式：{4}。", this.jobDetail.sched_name, jobDetailNew.sched_name, jobDetailNew.description, tuple.Item1.Key, tuple.Item1.Key.Name, tuple.Item2[0].Key.Name, ""));
                        return; //退出
                    }
                    //执行具体作业的业务逻辑
                    this.ExecuteJobImpl(context);
                }
                catch (Exception ex)
                {
                    SysParams.logger.Info(string.Format("【{0}】执行作业失败，消息：{1}", JobName, ex.Message + ex.StackTrace));
                }
                finally
                {
                    if (IsWriteScheduleJobLogAtParent)
                    {
                        WirteScheduleLog(context);
                    }
                }
            }
            catch (Exception ex)
            {
                SysParams.logger.Info(string.Format("【{0}】执行作业报错，消息：{1}", JobName, ex.Message + ex.StackTrace));
            }
        }

        /// <summary>
        /// 写执行日志到数据库
        /// </summary>
        /// <param name="context"></param>
        protected void WirteScheduleLog(IJobExecutionContext context)
        {
            string _result = string.Format("【{0}】执行完毕，执行结果：{1}", this.JobName, context.Get("ExecResult") != null ? context.Get("ExecResult").ToString() : "失败");
            if (ScheduleSet.writeTxtLog) SysParams.logger.Info(_result);
            WriteScheduleJob_Log _ScheduleLog = null;
            if (jobDetail == null)
                _ScheduleLog = new WriteScheduleJob_Log { sched_name = "", description = _result, success = false, update_time = ExeEndQueryTime.ToString("yyyy/MM/dd HH:mm:ss.fff") };
            else
                _ScheduleLog = new WriteScheduleJob_Log { sched_name = jobDetail.sched_name, description = _result, job_name = jobDetail.job_name, success = context.Get("ExecResult") != null && context.Get("ExecResult").ToString() == "成功" ? true : false, update_time = ExeEndQueryTime.ToString("yyyy/MM/dd HH:mm:ss.fff") };
            //if (this.jobDetail != null && this.jobDetail.is_durable)
            //    schedulebLL.WirteScheduleLog(_ScheduleLog);
        }

        private bool IsChangedTrigger(IEnumerable<ScheduleJob_Details_Triggers> oldTrigger, IEnumerable<ScheduleJob_Details_Triggers> newTrigger)
        {
            if (oldTrigger == null || oldTrigger.Count() == 0 || newTrigger == null || newTrigger.Count() == 0 || oldTrigger.Count() != newTrigger.Count())
                return true;
            foreach (var oldTriggerItem in oldTrigger)
            {
                var newTriggerItem = newTrigger.Where(n => n.sched_name == oldTriggerItem.sched_name && n.job_name == oldTriggerItem.job_name && n.trigger_name == oldTriggerItem.trigger_name);
                if (newTriggerItem == null || newTriggerItem.Count() == 0 || !oldTriggerItem.scheEquals(newTriggerItem.FirstOrDefault()))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 执行具体作业逻辑，子类实现若有异常，必须把异常抛回父类
        /// </summary>
        protected virtual void ExecuteJobImpl(IJobExecutionContext context)
        {

        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="error"></param>
        /// <param name="args"></param>
        protected void WriteLog(string error)
        {
            try
            {
                SysParams.logger.Error(error);
            }
            catch { }
        }

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="error"></param>
        /// <param name="args"></param>
        protected void WriteLog(string error, params object[] args)
        {
            try
            {
                SysParams.logger.Error(string.Format("【{0}】分页执行出错, 错误原因：{1}", args));
            }
            catch { }
        }
    }
}
