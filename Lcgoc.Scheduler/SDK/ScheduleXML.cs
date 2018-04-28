using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Lcgoc.Model;
using System.ComponentModel;

namespace Lcgoc.Scheduler
{
    public class ScheduleXML
    {
        /// <summary>
        /// 当前作业目录
        /// </summary>
        public static string FilePath = System.Environment.CurrentDirectory + "\\SchedulerModel.xml";
        public static string ModelPath = System.Environment.CurrentDirectory + "\\SchedulerModel.xml";

        public static string ScheduleElem = "scheduler";
        public static string scheduleJob = "schedulejob";
        public static string scheduleJobDetails = "schedulejob_details";
        public static string scheduleJobDetailsTriggers = "schedulejob_details_triggers";
        //存储数据的标签名
        public static string elemItem = "item";

        XmlDocument xmlDoc;
        /// <summary>
        /// 开始标签
        /// </summary>
        XmlElement xmlElem;

        public ScheduleXML()
        {
            if (!File.Exists(FilePath))
            {
                xmlDoc = new XmlDocument();
                XmlDeclaration xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmlDoc.AppendChild(xmldecl);
                AddElem(ScheduleElem, null);
                xmlDoc.Save(FilePath);
            }
            else
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(FilePath);
                xmlElem = (XmlElement)xmlDoc.SelectSingleNode(ScheduleElem);//查找
            }
        }

        /// <summary>
        /// 查找作业
        /// </summary>
        /// <param name="schedName"></param>
        /// <param name="jobName"></param>
        /// <returns></returns>
        public List<ScheduleJob> QuerySchedule(string schedName = "", string jobName = "")
        {
            List<ScheduleJob> resultList = new List<ScheduleJob>();
            var node = xmlElem.SelectSingleNode(scheduleJob);
            var scheduleItem = ((XmlElement)node).SelectNodes(elemItem);
            foreach (XmlElement item in scheduleItem)
            {
                if (!string.IsNullOrEmpty(schedName) && !string.IsNullOrEmpty(jobName))
                {
                    if (item.GetAttribute("sched_name") != schedName || item.GetAttribute("job_name") != jobName)
                        continue;
                }
                else if (!string.IsNullOrEmpty(schedName) && string.IsNullOrEmpty(jobName))
                {
                    if (item.GetAttribute("sched_name") != schedName)
                        continue;
                }
                resultList.Add(XMLTOModel<ScheduleJob>(item));
            }
            return resultList;
        }

        /// <summary>
        /// 根据作业名查找job
        /// </summary>
        /// <param name="schedName"></param>
        /// <returns></returns>
        public List<ScheduleJob_Details> QueryJobDetails(string schedName = "", string jobName = "")
        {
            List<ScheduleJob_Details> resultList = new List<ScheduleJob_Details>();
            var node = xmlElem.SelectSingleNode(scheduleJobDetails);
            var scheduleItem = ((XmlElement)node).SelectNodes(elemItem);
            foreach (XmlElement item in scheduleItem)
            {
                if (!string.IsNullOrEmpty(schedName) && !string.IsNullOrEmpty(jobName))
                {
                    if (item.GetAttribute("sched_name") != schedName || item.GetAttribute("job_name") != jobName)
                        continue;
                }
                else if (!string.IsNullOrEmpty(schedName) && string.IsNullOrEmpty(jobName))
                {
                    if (item.GetAttribute("sched_name") != schedName)
                        continue;
                }
                resultList.Add(XMLTOModel<ScheduleJob_Details>(item));
            }
            return resultList;
        }

        /// <summary>
        /// 触发器
        /// </summary>
        /// <param name="schedName"></param>
        /// <returns></returns>
        public IEnumerable<ScheduleJob_Details_Triggers> QueryTriggers(string schedName = "", string jobName = "")
        {
            List<ScheduleJob_Details_Triggers> resultList = new List<ScheduleJob_Details_Triggers>();
            var node = xmlElem.SelectSingleNode(scheduleJobDetailsTriggers);
            var scheduleItem = ((XmlElement)node).SelectNodes(elemItem);
            foreach (XmlElement item in scheduleItem)
            {
                if (!string.IsNullOrEmpty(schedName) && !string.IsNullOrEmpty(jobName))
                {
                    if (item.GetAttribute("sched_name") != schedName || item.GetAttribute("job_name") != jobName)
                        continue;
                }
                else if (!string.IsNullOrEmpty(schedName) && string.IsNullOrEmpty(jobName))
                {
                    if (item.GetAttribute("sched_name") != schedName)
                        continue;
                }
                resultList.Add(XMLTOModel<ScheduleJob_Details_Triggers>(item));
            }
            return resultList;
        }

        #region 私有方法

        /// <summary>
        /// XML转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T XMLTOModel<T>(XmlElement elem)
        {
            T obj = System.Activator.CreateInstance<T>();
            System.Reflection.PropertyInfo[] pis = typeof(T).GetProperties();
            foreach (System.Reflection.PropertyInfo pi in pis)
            {
                var g = elem.SelectSingleNode(pi.Name);
                if (g != null)
                {
                    try
                    {
                        pi.SetValue(obj, Convert.ChangeType(((XmlElement)g).InnerText, pi.PropertyType), null);
                    }
                    catch { continue; }
                }
            }
            return obj;
        }

        /// <summary>
        /// 增加
        /// </summary>
        private XmlElement AddElem(string elemName, XmlElement parentElem)
        {
            XmlElement newElem = null;
            if (parentElem == null)
            {
                newElem = xmlDoc.CreateElement(elemName);
                xmlDoc.AppendChild(newElem);
            }
            else
            {
                newElem = xmlDoc.CreateElement(elemName);
                parentElem.AppendChild(newElem);
            }
            return newElem;
        }

        #endregion

        public bool SaveScheduleJob(BindingList<ScheduleJob> schedule)
        {
            var node = xmlElem.SelectSingleNode(scheduleJob);
            node.RemoveAll();
            if (schedule.Count > 0)
            {
                foreach (var item in schedule)
                {
                    var eItem = xmlDoc.CreateElement("item");
                    eItem.SetAttribute("sched_name", item.sched_name);
                    eItem.SetAttribute("job_name", item.job_name);
                    node.AppendChild(eItem);

                    var sched_name = xmlDoc.CreateElement("sched_name");
                    sched_name.InnerText = item.sched_name;
                    eItem.AppendChild(sched_name);

                    var job_name = xmlDoc.CreateElement("job_name");
                    job_name.InnerText = item.job_name;
                    eItem.AppendChild(job_name);

                    var WriteDBLog = xmlDoc.CreateElement("WriteDBLog");
                    WriteDBLog.InnerText = item.writeDBLog.ToString();
                    eItem.AppendChild(WriteDBLog);

                    var WriteTxtLog = xmlDoc.CreateElement("WriteTxtLog");
                    WriteTxtLog.InnerText = item.writeTxtLog.ToString();
                    eItem.AppendChild(WriteTxtLog);

                    var AllowUsed = xmlDoc.CreateElement("AllowUsed");
                    AllowUsed.InnerText = item.allowUsed.ToString();
                    eItem.AppendChild(AllowUsed);
                }
            }
            xmlDoc.Save(FilePath);
            return true;
        }
        public bool SaveScheduleDetail(BindingList<ScheduleJob_Details> scheduleDetail)
        {
            var node = xmlElem.SelectSingleNode(scheduleJobDetails);
            node.RemoveAll();
            if (scheduleDetail.Count > 0)
            {
                foreach (var item in scheduleDetail)
                {
                    var eItem = xmlDoc.CreateElement("item");
                    eItem.SetAttribute("sched_name", item.sched_name);
                    eItem.SetAttribute("job_name", item.job_name);
                    node.AppendChild(eItem);

                    var sched_name = xmlDoc.CreateElement("sched_name");
                    sched_name.InnerText = item.sched_name;
                    eItem.AppendChild(sched_name);

                    var job_name = xmlDoc.CreateElement("job_name");
                    job_name.InnerText = item.job_name;
                    eItem.AppendChild(job_name);

                    var job_group = xmlDoc.CreateElement("job_group");
                    job_group.InnerText = item.job_group;
                    eItem.AppendChild(job_group);

                    var description = xmlDoc.CreateElement("description");
                    description.InnerText = item.description;
                    eItem.AppendChild(description);

                    var job_class_name = xmlDoc.CreateElement("job_class_name");
                    job_class_name.InnerText = item.job_class_name;
                    eItem.AppendChild(job_class_name);

                    var is_durable = xmlDoc.CreateElement("is_durable");
                    is_durable.InnerText = item.is_durable.ToString();
                    eItem.AppendChild(is_durable);
                    
                    var StartTime = xmlDoc.CreateElement("StartTime");
                    StartTime.InnerText = item.startTime.ToString();
                    eItem.AppendChild(StartTime);

                    var EndTime = xmlDoc.CreateElement("EndTime");
                    EndTime.InnerText = item.endTime.ToString();
                    eItem.AppendChild(EndTime);
                }
            }
            xmlDoc.Save(FilePath);
            return true;
        }
        public bool SaveScheduleTriggers(BindingList<ScheduleJob_Details_Triggers> scheduleTriggers)
        {
            var node = xmlElem.SelectSingleNode(scheduleJobDetailsTriggers);
            node.RemoveAll();
            if (scheduleTriggers.Count > 0)
            {
                foreach (var item in scheduleTriggers)
                {
                    var eItem = xmlDoc.CreateElement("item");
                    eItem.SetAttribute("sched_name", item.sched_name);
                    eItem.SetAttribute("job_name", item.job_name);
                    node.AppendChild(eItem);

                    var sched_name = xmlDoc.CreateElement("sched_name");
                    sched_name.InnerText = item.sched_name;
                    eItem.AppendChild(sched_name);

                    var job_name = xmlDoc.CreateElement("job_name");
                    job_name.InnerText = item.job_name;
                    eItem.AppendChild(job_name);

                    var trigger_name = xmlDoc.CreateElement("trigger_name");
                    trigger_name.InnerText = item.trigger_name.ToString();
                    eItem.AppendChild(trigger_name);

                    var trigger_group = xmlDoc.CreateElement("trigger_group");
                    trigger_group.InnerText = item.trigger_group.ToString();
                    eItem.AppendChild(trigger_group);

                    var job_group = xmlDoc.CreateElement("job_group");
                    job_group.InnerText = item.job_group.ToString();
                    eItem.AppendChild(job_group);

                    var description = xmlDoc.CreateElement("description");
                    description.InnerText = item.description.ToString();
                    eItem.AppendChild(description);

                    var cronexpression = xmlDoc.CreateElement("cronexpression");
                    cronexpression.InnerText = item.cronexpression.ToString();
                    eItem.AppendChild(cronexpression);

                    var repeat_count = xmlDoc.CreateElement("repeat_count");
                    repeat_count.InnerText = item.repeat_count.ToString();
                    eItem.AppendChild(repeat_count);

                    var repeat_interval = xmlDoc.CreateElement("repeat_interval");
                    repeat_interval.InnerText = item.repeat_interval.ToString();
                    eItem.AppendChild(repeat_interval);

                    var StartTime = xmlDoc.CreateElement("StartTime");
                    StartTime.InnerText = item.start_Time.ToString();
                    eItem.AppendChild(StartTime);

                    var EndTime = xmlDoc.CreateElement("EndTime");
                    EndTime.InnerText = item.end_Time.ToString();
                    eItem.AppendChild(EndTime);

                    var trigger_type = xmlDoc.CreateElement("trigger_type");
                    trigger_type.InnerText = item.trigger_type.ToString();
                    eItem.AppendChild(trigger_type);
                }
            }
            xmlDoc.Save(FilePath);
            return true;
        }

    }
}
