
namespace Lcgoc.Model
{
    public class ScheduleJob
    {
        public int id { get; set; }
        /// <summary>
        /// 采集器名称
        /// </summary>
        public string sched_name { get; set; }
        /// <summary>
        /// 采集作业名称
        /// </summary>
        public string job_name { get; set; }
        /// <summary>
        /// 是否写日志到数据库
        /// </summary>
        public bool writeDBLog { get; set; }
        /// <summary>
        /// 是否写日志到文本
        /// </summary>
        public bool writeTxtLog { get; set; }
        /// <summary>
        /// 是否可以使用
        /// </summary>
        public bool allowUsed { get; set; }
    }
}
