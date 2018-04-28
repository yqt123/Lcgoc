using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using NLog;
using System.Threading;
using Lcgoc.Model;
using System.Windows.Forms;

namespace Lcgoc.Scheduler
{
    public class MyTestJob : JobBase
    {

        private static readonly object lockObj = new object(); //锁对象
        public MyTestJob()
        {
            JobName = "测试作业";
        }

        /// <summary>
        /// 作业执行
        /// </summary>
        protected override void ExecuteJobImpl(Quartz.IJobExecutionContext context)
        {
            if (System.Threading.Monitor.TryEnter(lockObj))
            {
                string upData = string.Empty;
                string result = string.Empty;
                string remark = string.Empty;
                try
                {
                    if (ScheduleSet.WriteTxtLog)
                        SysParams.logger.Info(string.Format("【{0}】已经开始", JobName));
                    string lastSuccessTime = new ScheduleSDK().LastSuccessTimeDAL(this.jobDetail.sched_name, this.jobDetail.job_name);

                    if (ScheduleSet.WriteTxtLog)
                        context.Put("ExecResult", "成功");
                }
                catch (Exception ex)
                {
                    SysParams.logger.Error(string.Format("【{0}】出错, 错误原因：{1}", jobDetail.description, ex.Message));
                    context.Put("ExecResult", "失败");
                }
                finally
                {
                    if (ScheduleSet.WriteTxtLog) SysParams.logger.Info(string.Format("【{0}】结束", JobName));
                    base.WirteScheduleLog(context);
                    base.IsWriteScheduleJobLogAtParent = false;
                    System.Threading.Monitor.Exit(lockObj);
                }
            }
            else
            {
                base.IsWriteScheduleJobLogAtParent = false;
                context.Put("ExecResult", "失败,作业正在执行..");
                ExeEndQueryTime = DateTime.Now;
                base.WirteScheduleLog(context);
            }
        }

    }
}
