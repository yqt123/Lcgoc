using Quartz;

namespace Lcgoc.SchedulerJob
{
    public class MyTestJob : IJob
    {
        private static readonly object lockObj = new object(); //锁对象
        /// <summary>
        /// 作业执行
        /// </summary>
        public void Execute(IJobExecutionContext context)
        {
            //if (System.Threading.Monitor.TryEnter(lockObj))
            //{
            //}
            //else
            //{
            //}
        }

    }
}
