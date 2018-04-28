
namespace Lcgoc.Model
{
    public class ScheduleJob_Details
    {
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
        /// 采集作业说明
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 采集作业执行类名（完整的类名）
        /// </summary>
        public string job_class_name { get; set; }
        /// <summary>
        /// 是否可以使用
        /// </summary>
        public bool is_durable { get; set; }
        /// <summary>
        /// 开始采集时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 结束采集时间（可以不设置）
        /// </summary>
        public string endTime { get; set; }
        /// <summary>
        /// 比较值是否相等
        /// </summary>
        /// <param name="plNew"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            ScheduleJob_Details jobDetail = obj as ScheduleJob_Details;
            return jobDetail != null &&
                jobDetail.sched_name == sched_name &&
                jobDetail.job_name == job_name &&
                jobDetail.job_group == job_group &&
                jobDetail.description == description &&
                jobDetail.job_class_name == job_class_name &&
                jobDetail.is_durable == is_durable &&
                jobDetail.startTime == startTime &&
                jobDetail.endTime == endTime;
        }
    }
}
