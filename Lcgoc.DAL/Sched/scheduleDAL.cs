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

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ScheduleDelete(int id)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format("DELETE FROM scheduleJob where id='{0}';", id);
                return connection.Execute(sql) > 0;
            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ScheduleAdd(ScheduleJob data)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format(
@"INSERT INTO scheduleJob(id,sched_name,job_name,writeDBLog,writeTxtLog,allowused)
VALUES({0}, '{1}', '{2}', {3}, {4}, {5}); ", data.id, data.sched_name, data.job_name, data.writeDBLog ? 1 : 0, data.writeTxtLog ? 1 : 0, data.allowUsed ? 1 : 0);
                return connection.Execute(sql) > 0;
            }
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ScheduleEdit(ScheduleJob data)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format(
@"update scheduleJob set sched_name='{1}',job_name='{2}',writeDBLog={3},writeTxtLog={4},allowused={5})
where id={0}; ", data.id, data.sched_name, data.job_name, data.writeDBLog ? 1 : 0, data.writeTxtLog ? 1 : 0, data.allowUsed ? 1 : 0);
                return connection.Execute(sql) > 0;
            }
        }

        /// <summary>
        /// 查找调度作业
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<ScheduleJob_Details> QueryScheduleDetails(string schedName = "", string jobName = "")
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = "SELECT * FROM scheduleJob_details ";
                if (!string.IsNullOrEmpty(schedName) && !string.IsNullOrEmpty(schedName))
                {
                    sql += string.Format("where sched_name='{0}' and job_name='{1}';", schedName, jobName);
                }
                return connection.Query<ScheduleJob_Details>(sql);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ScheduleDetailsDelete(int id)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format("DELETE FROM scheduleJob_details where id='{0}';", id);
                return connection.Execute(sql) > 0;
            }
        }

        /// <summary>
        /// 查找调度作业
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public IEnumerable<ScheduleJob_Details_Triggers> QueryScheduleDetailsTriggers(string schedName = "", string jobName = "")
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = "SELECT * FROM scheduleJob_details_triggers ";
                if (!string.IsNullOrEmpty(schedName) && !string.IsNullOrEmpty(schedName))
                {
                    sql += string.Format("where sched_name='{0}' and job_name='{1}';", schedName, jobName);
                }
                return connection.Query<ScheduleJob_Details_Triggers>(sql);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ScheduleDetailsTriggersDelete(int id)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format("DELETE FROM scheduleJob_details_triggers where id='{0}';", id);
                return connection.Execute(sql) > 0;
            }
        }

    }
}
