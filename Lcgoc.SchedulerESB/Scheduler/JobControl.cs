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
            var jobDetails = bll.QueryScheduleDetails();
            //检查有没有删除的作业
            foreach (ScheduleJob_Details item in JobHelper.schedulePlanDetails.Values)
            {
                var old = jobDetails.Where(n => n.job_name == item.job_name && n.sched_name == item.sched_name && n.is_durable);
                if (old.Count() == 0)
                {
                    context.Scheduler.DeleteJob(JobHelper.GetJobKey(item));
                    JobHelper.schedulePlanDetails.Remove(JobHelper.GetJobKey(item) + JobHelper.jobDetailMad);
                }
            }
            //检查有没有修改过的作业
            foreach (ScheduleJob_Details item in jobDetails)
            {

                var old = JobHelper.schedulePlanDetails[JobHelper.GetJobKey(item) + JobHelper.jobDetailMad] as ScheduleJob_Details;
                if (old == null)
                {
                    JobHelper.ScheduleJobByPlan(context.Scheduler, item);
                    JobHelper.schedulePlanDetails.Add(JobHelper.GetJobKey(item) + JobHelper.jobDetailMad, item);
                    continue;
                }
                if (!item.scheEquals(old))
                {
                    //移除并写入新的作业
                    JobHelper.schedulePlanDetails.Remove(JobHelper.GetJobKey(item) + JobHelper.jobDetailMad);
                    JobHelper.schedulePlanDetails.Add(JobHelper.GetJobKey(item) + JobHelper.jobDetailMad, item);
                    JobHelper.RestartJob(context.Scheduler, old, item);
                }
            }
        }
    }
}
