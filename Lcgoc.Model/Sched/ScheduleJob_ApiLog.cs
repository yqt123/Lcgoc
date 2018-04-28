
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
        public string apiLogId { get; set; }
        /// <summary>
        /// 接口
        /// </summary>
        public string apiID { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string apiName { get; set; }
        /// <summary>
        /// 传递参数
        /// </summary>
        public string post { get; set; }
        /// <summary>
        /// 返回参数
        /// </summary>
        public string get { get; set; }
        /// <summary>
        /// 执行结果 0成功，1失败
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public string modifyDTM { get; set; }
        /// <summary>
        /// 接口开始执行时间
        /// </summary>
        public string startTime { get; set; }
        /// <summary>
        /// 接口结束时间
        /// </summary>
        public string endTime { get; set; }
    }
}
