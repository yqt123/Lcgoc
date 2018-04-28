using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using NLog;
using System.Threading;
using Lcgoc.Model;
using System.Windows.Forms;
using System.Data;

namespace Lcgoc.Scheduler
{
    public class MessageSendJob : JobBase
    {

        private static readonly object lockObj = new object(); //锁对象
        public MessageSendJob()
        {
            JobName = "信息发送作业";
        }

        /// <summary>
        /// 作业执行
        /// </summary>
        protected override void ExecuteJobImpl(Quartz.IJobExecutionContext context)
        {
            if (System.Threading.Monitor.TryEnter(lockObj))
            {
                string upData = string.Empty;
                string result = string.Empty;
                string remark = string.Empty;
                try
                {
                    if (ScheduleSet.WriteTxtLog)
                        SysParams.logger.Info(string.Format("【{0}】已经开始", this.jobDetail.description));
                    //检查需要发送的信息
                    var messgeSends = new ScheduleSDK().GetMessageSend(this.jobDetail.sched_name, this.jobDetail.job_name);
                    List<MessageSend> items = new List<MessageSend>();
                    if (messgeSends != null && messgeSends.Count > 0)
                    {
                        var WXObj = (from p in messgeSends
                                     where p.TempletType == "WX"
                                     select p); //Take()取前几条记录
                        //var WXObj = (from n in messgeSends select new MessageSend() { TempletType = "WX",HasSend=0, Keyword, KeywordValue, Mobile, OpenId, SendId, SendNums, TempletID, TempletSequence, Url });
                        var WXObjMaster = WXObj.GroupBy(p => new { p.SendId }).Select(g => g.First()).ToList();
                        foreach (MessageSend item in WXObjMaster)
                        {
                            //发送动作
                            bool success = true;
                            // var WXObjDetail = (from n in WXObj select new MessageSend() { SendId = item.SendId });
                            var WXObjDetail = (from p in WXObj
                                               where p.SendId == item.SendId
                                               select p);
                            success = SendWXMsg(WXObjDetail.ToArray());

                            //修改消息状态
                            if (success)
                            {
                                item.SendNums += 1;
                                item.HasSend = 1;
                                items.Add(item);
                            }
                        }
                        // var SMSObj = (from n in messgeSends select new MessageSend() { TempletType = "SMS" });
                        var SMSObj = (from p in messgeSends
                                      where p.TempletType == "SMS"
                                      select p);
                        var SMSObjMaster = SMSObj.GroupBy(p => new { p.SendId }).Select(g => g.First()).ToList();
                        foreach (MessageSend item in SMSObjMaster)
                        {
                            //发送动作
                            bool success = true;
                            //  var SMSObjDetail = (from n in WXObj select new MessageSend() { SendId = item.SendId });
                            var SMSObjDetail = (from p in SMSObj
                                                where p.SendId == item.SendId
                                                select p);
                            success = SendSMSMsg(SMSObjDetail.ToArray());

                            //修改消息状态
                            if (success)
                            {
                                item.SendNums += 1;
                                item.HasSend = 1;
                                items.Add(item);
                            }

                        }

                        //客服消息推送
                        var WXmsgs = messgeSends.Where(n => n.TempletType == "WXMSG");
                        if (WXmsgs != null)
                            foreach (MessageSend item in WXmsgs)
                            {
                                //发送动作
                                //bool success = true;
                                //var weChatBasicRs = WeChat.Core.WxMsgCommon.PushText(item.OpenId, item.KeywordValue);
                                //success = weChatBasicRs.IsSuccess;
                                ////修改消息状态
                                //if (success)
                                //{
                                //    item.SendNums += 1;
                                //    item.HasSend = 1;
                                //    items.Add(item);
                                //}
                            }

                        //修改结果回传数据库
                        if (items.Count > 0) new ScheduleSDK().MessageSendDeal(items);
                    }
                    context.Put("ExecResult", "成功");
                }
                catch (Exception ex)
                {
                    SysParams.logger.Info(string.Format("【{0}】出错, 错误原因：{1}", jobDetail.description, ex.Message));
                    context.Put("ExecResult", "失败");
                }
                finally
                {
                    if (ScheduleSet.WriteTxtLog) SysParams.logger.Info(string.Format("【{0}】结束", JobName));
                    base.WirteScheduleLog(context);
                    base.IsWriteScheduleJobLogAtParent = false;
                    System.Threading.Monitor.Exit(lockObj);
                }
            }
            else
            {
                base.IsWriteScheduleJobLogAtParent = false;
                context.Put("ExecResult", "失败,作业正在执行..");
                ExeEndQueryTime = DateTime.Now;
                base.WirteScheduleLog(context);
            }
        }

        private bool SendWXMsg(Lcgoc.Model.MessageSend[] obj)
        {
            //if (obj == null || obj.Length == 0)
            //    return false;
            //Dictionary<string, WeChat.Core.ModelMsg.TemplateItemData> dictionary = new Dictionary<string, WeChat.Core.ModelMsg.TemplateItemData>();
            //WeChat.Core.ModelMsg.TemplateItemData data;
            //foreach (MessageSend item in obj)
            //{
            //    data = new WeChat.Core.ModelMsg.TemplateItemData();
            //    data.value = item.KeywordValue;
            //    dictionary.Add(item.Keyword, data);
            //}
            //var result = WeChat.Core.ModelMsg.TemplateAPI.SendTemplateMsg(WeChat.Core.Common.WxComnon.GetAccessToken().AccessToken, obj[0].OpenId, obj[0].TempletID, "", obj[0].Url, dictionary);
            //WeChat.Core.ModelMsg.SendTemplateMsgResult resultClass = new WeChat.Core.ModelMsg.SendTemplateMsgResult();
            //resultClass = result;
            return true;
        }

        private bool SendSMSMsg(Lcgoc.Model.MessageSend[] obj)
        {
            //if (obj == null || obj.Length == 0)
            //    return false;
            //var q =
            //from c in obj
            //orderby c.TempletSequence
            //select c;
            //List<string> str = new List<string>();
            //foreach (MessageSend item in q)
            //{
            //    str.Add(item.KeywordValue);
            //}

            //CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();
            ////ip格式如下，不带https://
            //bool isInit = api.init("sandboxapp.cloopen.com", "8883");
            ////api.setAccount(主帐号, 主帐号令牌);
            ////api.setAppId(应用ID);
            //api.setAccount("aaf98f89512446e201514346067d5d70", "227659ae319b4bf588d039b0deddc505");
            //api.setAppId("8a48b5515147eb6d01516151376a3ffa");
            //try
            //{
            //    if (isInit)
            //    {
            //        //Dictionary<string, object> retData = api.SendTemplateSMS(短信接收号码, 短信模板id, 内容数据);
            //        Dictionary<string, object> retData = api.SendTemplateSMS(obj[0].Mobile, obj[0].TempletID, str.ToArray());
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception exc)
            //{
            //    return false;
            //}
            return true;
        }


    }
}
