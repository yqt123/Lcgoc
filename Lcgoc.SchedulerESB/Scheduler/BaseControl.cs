using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using NLog;
using Lcgoc.Model;
using Lcgoc.BLL;

namespace Lcgoc.SchedulerESB
{
    public class BaseControl : IJob
    {
        /// <summary>
        /// IJob执行作业，使用context在子类和基类之间传值，执行成功或者失败的值由context从子类带回来
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            string jobName = string.Empty;
            ScheduleJob_Details jobDetail = context.MergedJobDataMap[JobHelper.jobDetailMad] as ScheduleJob_Details;
            try
            {
                if (jobDetail == null)
                {
                    context.Put("ExecResult", "作业计划不存在");
                    throw new Exception(string.Format("本次执行失败,作业计划不存在！"));
                }
                jobName = jobDetail.description;
                SysParams.logger.Info(string.Format("【{0}】本次开始执行...", jobName));

                ExecuteOutJob(jobDetail, context);

                context.Put("ExecResult", "完成");
                SysParams.logger.Info(string.Format("【{0}】本次执行结束。", jobName));
            }
            catch (Exception ex)
            {
                SysParams.logger.Info(string.Format("【{0}】执行作业失败，消息：{1}", jobName, ex.Message));
            }
            finally
            {
                if (jobDetail != null)
                    new ScheduleBLL().SaveScheduleLog(new ScheduleJob_Log
                    {
                        description = string.Format("【{0}】执行完毕，执行结果：{1}", jobName, context.Get("ExecResult") != null ? context.Get("ExecResult").ToString() : "失败"),
                        job_name = jobDetail.job_name,
                        sched_name = jobDetail.sched_name,
                        update_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff"),
                        success = (context.Get("ExecResult") != null && context.Get("ExecResult").ToString() == "成功" ? true : false)
                    });
            }
        }

        /// <summary>
        /// 执行外部作业
        /// </summary>
        void ExecuteOutJob(ScheduleJob_Details jobDetail, IJobExecutionContext context)
        {
            Type jobType = null;
            if (!string.IsNullOrEmpty(jobDetail.outAssembly))
            {
                System.Reflection.Assembly outerAsm = System.Reflection.Assembly.LoadFrom(System.AppDomain.CurrentDomain.BaseDirectory + jobDetail.outAssembly);
                jobType = outerAsm.GetType(jobDetail.job_class_name);
            }
            else
            {
                jobType = Type.GetType(jobDetail.job_class_name);
            }
            var job = (IJob)Activator.CreateInstance(jobType);
            job.Execute(context);
        }
    }
}
