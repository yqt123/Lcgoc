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
@"update scheduleJob set sched_name='{1}',job_name='{2}',writeDBLog={3},writeTxtLog={4},allowused={5}
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
        /// 写入数据
        /// </summary>
        /// <returns></returns>
        public bool ScheduleDetailsAdd(ScheduleJob_Details data)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format(
@"INSERT INTO ScheduleJob_Details(id,sched_name,job_name,job_group,outAssembly,job_class_name,is_durable,description,startTime,endTime)
VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}','{6}','{7}','{8}','{9}'); ", data.id, data.sched_name, data.job_name, data.job_group,data.outAssembly, data.job_class_name, data.is_durable?1:0, data.description, data.startTime, data.endTime);
                return connection.Execute(sql) > 0;
            }
        }

        public bool ScheduleDetailsEdit(ScheduleJob_Details data)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format(
@"UPDATE ScheduleJob_Details set sched_name='{1}',job_name='{2}',job_group='{3}',outAssembly='{4}',job_class_name= '{5}',is_durable='{6}',description='{7}',startTime='{8}',endTime='{9}'
where id={0};", data.id, data.sched_name, data.job_name, data.job_group, data.outAssembly, data.job_class_name, data.is_durable ? 1 : 0, data.description, data.startTime, data.endTime);
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
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ScheduleDetailsTriggersAdd(ScheduleJob_Details_Triggers data)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format(
@"INSERT INTO ScheduleJob_Details_Triggers(id,sched_name,job_name,trigger_name,trigger_group,job_group,cronexpression,trigger_type,repeat_count,repeat_interval,startTime,endTime)
VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}','{6}','{7}','{8}','{9}','{10}','{11}'); ", data.id, data.sched_name, data.job_name, data.trigger_name, data.trigger_group, data.job_group, data.cronexpression, data.trigger_type, data.repeat_count, data.repeat_interval, data.startTime, data.endTime);
                return connection.Execute(sql) > 0;
            }
        }
        public bool ScheduleDetailsTriggersEdit(ScheduleJob_Details_Triggers data)
        {
            using (IDbConnection connection = new SQLiteConnectionHelper().connectionGetAndOpen())
            {
                var sql = string.Format(
@"UPDATE ScheduleJob_Details_Triggers set sched_name='{1}',job_name='{2}',trigger_name='{3}',trigger_group='{4}',job_group='{5}',cronexpression='{6}',trigger_type='{7}',repeat_count='{8}',repeat_interval='{9}',startTime='{10}',endTime='{11}'
where id={0}; ", data.id, data.sched_name, data.job_name, data.trigger_name, data.trigger_group, data.job_group, data.cronexpression, data.trigger_type, data.repeat_count, data.repeat_interval, data.startTime, data.endTime);
                return connection.Execute(sql) > 0;
            }
        }
    }
}
