using Dapper;
using Lcgoc.Common;
using Lcgoc.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lcgoc.DAL
{
    public class ScheduleDAL
    {
        /// <summary>
        /// 查找调度作业
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<ScheduleJob> QuerySchedule(string schedName = "", string jobName = "")
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = "SELECT * FROM scheduleJob ";
                if (!string.IsNullOrEmpty(schedName) && !string.IsNullOrEmpty(schedName))
                {
                    sql += string.Format("where sched_name='{0}' and job_name='{1}';", schedName, jobName);
                }
                return connection.Query<ScheduleJob>(sql);
            }
        }
    }
}
