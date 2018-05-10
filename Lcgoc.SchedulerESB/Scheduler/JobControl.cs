using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using NLog;
using Lcgoc.Model;
using Lcgoc.BLL;

namespace Lcgoc.SchedulerESB
{
    public class JobControl : IJob
    {
        #region 声明
        private static readonly object lockObj = new object(); //锁对象
        ScheduleBLL bll = new ScheduleBLL();
        private string JobName = "主控作业";
        #endregion
        /// <summary>
        /// IJob执行作业，使用context在子类和基类之间传值，执行成功或者失败的值由context从子类带回来
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            if (System.Threading.Monitor.TryEnter(lockObj))
            {
                try
                {
                    var jobDetail = context.MergedJobDataMap[JobHelper.jobDetailMad] as ScheduleJob_Details;
                    if (jobDetail == null)
                    {
                        context.Put("ExecResult", "取不到作业计划");
                        throw new Exception(string.Format("【{0}】本次执行失败,取不到作业计划！", JobName));
                    }
                    SysParams.logger.Info(string.Format("【{0}】本次开始执行...", JobName));

                    //不从调度计划中删除本作业，因为有可能客户又启用该作业计划
                    if (!jobDetail.is_durable)
                    {
                        SysParams.logger.Info(string.Format("【{0}】作业计划不允许使用，跳过此次执行。", jobDetail.description));
                        context.Put("ExecResult", "完成");
                        return;
                    }
                    CheckAllSchedulerPlan(context);
                    context.Put("ExecResult", "完成");
                    SysParams.logger.Info(string.Format("【{0}】本次执行结束。", JobName));
                }
                catch (Exception ex)
                {
                    SysParams.logger.Info(string.Format("【{0}】执行作业失败，消息：{1}", JobName, ex.Message + ex.StackTrace));
                }
                System.Threading.Monitor.Exit(lockObj);
            }
            else
            {
                context.Put("ExecResult", string.Format("【{0}】本次执行失败,作业正在执行..", JobName));
            }
        }

        /// <summary>
        /// 检查所有调度作业，是否有变更
        /// </summary>
        private void CheckAllSchedulerPlan(IJobExecutionContext context)
        {
            var jobDetails = bll.QueryScheduleDetails().Where(n => n.is_durable);
            //检查有没有删除的作业
            foreach (ScheduleJob_Details item in JobHelper.schedulePlanDetails.Values)
            {
                var old = jobDetails.Where(n => n.job_name == item.job_name && n.sched_name == item.sched_name);
                if (old.Count() == 0)
                {
                    context.Scheduler.DeleteJob(JobHelper.GetJobKey(item));
                    JobHelper.schedulePlanDetails.Remove(JobHelper.GetJobKey(item) + JobHelper.jobDetailMad);
                }
            }
            //检查有没有修改过的作业
            foreach (ScheduleJob_Details item in jobDetails)
            {
                if (!JobHelper.schedulePlanDetails.Keys.Contains(JobHelper.GetJobKey(item) + JobHelper.jobDetailMad))
                {
                    JobHelper.ScheduleJobByPlan(context.Scheduler, item);
                    continue;
                }
                var oldDetails = JobHelper.schedulePlanDetails[JobHelper.GetJobKey(item) + JobHelper.jobDetailMad];
                var isChange = false;
                if (!item.scheEquals(oldDetails)) isChange = true;
                else
                {//检查触发器是否改变
                    var triggerNew = bll.QueryScheduleDetailsTriggers(schedName: item.sched_name, jobName: item.job_name);
                    var oldTrigger = JobHelper.schedulePlanTrigger[JobHelper.GetJobKey(item) + JobHelper.triggerMad];
                    if (triggerNew.Count() != oldTrigger.Count())
                        isChange = true;
                    else
                    {
                        foreach (ScheduleJob_Details_Triggers trigg in oldTrigger)
                        {
                            var _trigger = triggerNew.Where(n => n.sched_name == trigg.sched_name && n.job_name == trigg.job_name && n.trigger_name == trigg.trigger_name);
                            if (_trigger == null || _trigger.Count() == 0 || !trigg.scheEquals(_trigger.FirstOrDefault()))
                                isChange = true;
                        }
                    }
                }

                if (isChange)
                {
                    //移除并写入新的作业
                    context.Scheduler.DeleteJob(JobHelper.GetJobKey(item));
                    JobHelper.ScheduleJobByPlan(context.Scheduler, item);
                    //JobHelper.RestartJob(context.Scheduler, oldDetails, item);
                }
            }
        }
    }
}
