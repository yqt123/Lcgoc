
using System;

namespace Lcgoc.Model
{
    public class ScheduleJob_Status
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
        /// 采集作业组别
        /// </summary>
        public string job_group { get; set; }
        /// <summary>
        /// 采集作业触发器
        /// </summary>
        public string trigger_name { get; set; }
        /// <summary>
        /// 采集作业触发器组别
        /// </summary>
        public string trigger_group { get; set; }
        /// <summary>
        /// 采集作业说明
        /// </summary>
        public string description { get; set; }
        public string status { get; set; }
    }
}
