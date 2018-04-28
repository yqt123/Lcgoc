
namespace Lcgoc.Model
{
    /// <summary>
    /// API执行日志
    /// </summary>
    public class ScheduleJob_ApiLog
    {
        /// <summary>
        /// 流水ID
        /// </summary>
        public string LogID { get; set; }
        /// <summary>
        /// 接口
        /// </summary>
        public string ApiID { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// 公司代码
        /// </summary>
        public string CompanyID { get; set; }
        /// <summary>
        /// 日志ID
        /// </summary>
        public string SourceLogID { get; set; }
        /// <summary>
        /// 传递参数
        /// </summary>
        public string ParamValue { get; set; }
        /// <summary>
        /// 返回参数
        /// </summary>
        public string RetuenValue { get; set; }
        /// <summary>
        /// 执行结果 0成功，1失败
        /// </summary>
        public string LogState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public string ModifyDTM { get; set; }
        /// <summary>
        /// 接口开始执行时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 接口结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 调度
        /// </summary>
        public string Sched_Name { get; set; }
        /// <summary>
        /// 作业
        /// </summary>
        public string Job_Name { get; set; }
    }
}
