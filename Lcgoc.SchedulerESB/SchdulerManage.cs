using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lcgoc.Model;
using Lcgoc.BLL;
using System.Linq;
using Lcgoc.Common;

namespace Lcgoc.SchedulerESB
{
    public partial class SchdulerManage : DevExpress.XtraEditors.XtraForm
    {
        #region 声明
        BindingList<ScheduleJob_Details> details = new BindingList<ScheduleJob_Details>();
        BindingList<ScheduleJob_Details_Triggers> triggers = new BindingList<ScheduleJob_Details_Triggers>();
        BindingList<ScheduleJob_Status> jobStatus = new BindingList<ScheduleJob_Status>();
        BindingList<ScheduleJob_Log> jobLog = new BindingList<ScheduleJob_Log>();
        ScheduleBLL bll = new ScheduleBLL();

        int detailsmaxIndex = 0;
        int triggersmaxIndex = 0;

        Scheduler pcScheduler = null;
        #endregion

        #region 初始化
        public SchdulerManage(Scheduler _pcScheduler)
        {
            InitializeComponent();
            Init();
            pcScheduler = _pcScheduler;
        }

        private void Init()
        {
            navBar_scheduleJob_details.LinkClicked += NavBar_scheduleJob_details_LinkClicked;
            navBar_scheduleJob_details_triggers.LinkClicked += NavBar_scheduleJob_details_triggers_LinkClicked;
            navBar_schedulerSet.LinkClicked += NavBar_schedulerSet_LinkClicked;
            navBar_schedulerLog.LinkClicked += NavBar_schedulerLog_LinkClicked;
            tabPane1.SelectedPageIndexChanged += TabPane1_SelectedPageIndexChanged;
            tabPane1.SelectedPageIndex = 0;
            gridView2.CellValueChanged += GridView2_CellValueChanged;
            gridView3.CellValueChanged += GridView3_CellValueChanged;
            dte_start.EditValue = DateTime.Now;
            dte_end.EditValue = DateTime.Now;
            sbtn_refresh.Click += Sbtn_refresh_Click;
            sbtn_delete.Click += Sbtn_delete_Click;
        }

        #endregion

        #region 数据
        private void GridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = details.ElementAt(gridView2.FocusedRowHandle);
            bll.EditScheduleDetails(row);
        }

        private void GridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = triggers.ElementAt(gridView3.FocusedRowHandle);
            bll.EditScheduleDetailsTriggers(row);
        }

        private void TabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            var index = ((DevExpress.XtraBars.Navigation.TabPane)sender).SelectedPageIndex;
            BandingData(
                index == 0 ? "ScheduleDetails" :
                index == 1 ? "ScheduleDetailsTriggers" :
                index == 2 ? "ScheduleSet" :
                index == 3 ? "ScheduleLog" : ""
                );
        }
        void BandingData(string name)
        {
            switch (name)
            {
                case "ScheduleDetails":
                    {
                        details = new BindingList<ScheduleJob_Details>(bll.ListScheduleDetails().ToList());
                        if (details.Count > 0) detailsmaxIndex = details.Max(n => n.id);
                        gridDetail.DataSource = details;
                        XtraGridHelper.SetGridColumns(gridView2, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "id", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称", Width = 100 },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称", Width = 150},
                            new GridViewColumn { ColumnName = "job_group",Caption="作业组"},
                            new GridViewColumn { ColumnName = "outAssembly", Caption="调用外部程序集" },
                            new GridViewColumn { ColumnName = "job_class_name", Caption="调用类" },
                            new GridViewColumn { ColumnName = "is_durable", Caption="是否可用" },
                            new GridViewColumn { ColumnName = "description", Caption="描述" },
                            new GridViewColumn { ColumnName = "startTime", Caption="开始时间" },
                            new GridViewColumn { ColumnName = "endTime", Caption="结束时间" },
                            new GridViewColumn { ColumnName = "platformMonitoring", Caption="平台监控作业运行状况" },
                        });
                    }
                    break;
                case "ScheduleDetailsTriggers":
                    {
                        triggers = new BindingList<ScheduleJob_Details_Triggers>(bll.ListScheduleDetailsTriggers().ToList());
                        if (triggers.Count > 0) triggersmaxIndex = triggers.Max(n => n.id);
                        gridTrigger.DataSource = triggers;
                        XtraGridHelper.SetGridColumns(gridView3, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "id", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称", Width = 100 },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称" , Width = 150},
                            new GridViewColumn { ColumnName = "trigger_name", Caption="触发器", Width = 150 },
                            new GridViewColumn { ColumnName = "trigger_group", Caption="触发器组", Width = 150 },
                            new GridViewColumn { ColumnName = "job_group", Caption="作业组" },
                            new GridViewColumn { ColumnName = "cronexpression", Caption="触发规则", Width = 150 },
                            new GridViewColumn { ColumnName = "trigger_type", Caption="触发类型" },
                            new GridViewColumn { ColumnName = "repeat_count", Caption="触发次数（触发对应）" },
                            new GridViewColumn { ColumnName = "repeat_interval", Caption="触发间隔（触发对应）" },
                            new GridViewColumn { ColumnName = "startTime", Caption="开始时间" },
                            new GridViewColumn { ColumnName = "endTime", Caption="结束时间" },
                            new GridViewColumn { ColumnName = "description", Caption="描述"},
                        });
                    }
                    break;
                case "ScheduleSet":
                    {
                        List<ScheduleJob_Status> listScheduleJobStatus = new List<ScheduleJob_Status>();
                        foreach (IEnumerable<ScheduleJob_Details_Triggers> item in JobHelper.schedulePlanTrigger.Values.ToList())
                        {
                            foreach (ScheduleJob_Details_Triggers n in item)
                            {
                                var status = pcScheduler.GetTriggerState(n);
                                var statusName = "";
                                switch (status)
                                {
                                    case Quartz.TriggerState.Normal: statusName = "正常"; break;
                                    case Quartz.TriggerState.Paused: statusName = "暂停"; break;
                                    case Quartz.TriggerState.Complete: statusName = "结束"; break;
                                    case Quartz.TriggerState.Error: statusName = "出错"; break;
                                    case Quartz.TriggerState.Blocked: statusName = "堵塞"; break;
                                    case Quartz.TriggerState.None: statusName = "不存在"; break;
                                }
                                listScheduleJobStatus.Add(new ScheduleJob_Status
                                {
                                    description = n.description,
                                    id = n.id,
                                    job_group = n.job_group,
                                    job_name = n.job_name,
                                    sched_name = n.sched_name,
                                    trigger_group = n.trigger_group,
                                    trigger_name = n.trigger_name,
                                    status = statusName
                                });
                            }
                        }
                        if (listScheduleJobStatus.Count == 0) return;
                        jobStatus = new BindingList<ScheduleJob_Status>(listScheduleJobStatus);
                        grid_SchedulerSet.DataSource = jobStatus;

                        //停止按钮
                        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit itemButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        itemButton.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                        itemButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;//隐藏文字
                        itemButton.Buttons.RemoveAt(0);
                        var btnStop = new DevExpress.XtraEditors.Controls.EditorButton { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, Caption = "暂停作业" };
                        btnStop.Click += btnStop_Click;
                        itemButton.Buttons.Add(btnStop);
                        var btnRestart = new DevExpress.XtraEditors.Controls.EditorButton { Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, Caption = "重新开始" };
                        btnRestart.Click += btnRestart_Click;
                        itemButton.Buttons.Add(btnRestart);

                        XtraGridHelper.SetGridColumns(gridView_SchedulerSet, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "id", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称", AllowEdit = false, Width = 100 },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称", AllowEdit = false, Width = 150 },
                            new GridViewColumn { ColumnName = "job_group", Caption="作业组", AllowEdit = false, Width = 150 },
                            new GridViewColumn { ColumnName = "trigger_name", Caption="触发器", AllowEdit = false, Width = 150 },
                            new GridViewColumn { ColumnName = "trigger_group", Caption="触发器组", AllowEdit = false, Width = 150 },
                            new GridViewColumn { ColumnName = "description",  Caption="描述", AllowEdit = false},
                            new GridViewColumn { ColumnName = "status", Caption="运行状态", AllowEdit = false, Width = 100},
                            new GridViewColumn { ColumnName = "btn1", Caption="操作", IsNew = true, Width = 250,RepositoryItemButtonEdit=itemButton}
                        }, RowHeight: 25);
                    }
                    break;
                case "ScheduleLog":
                    {
                        jobLog = new BindingList<ScheduleJob_Log>(bll.ListScheduleJobLog(dte_start.EditValue == null ? DateTime.Now : (DateTime)dte_start.EditValue,
                            dte_end.EditValue == null ? DateTime.Now : (DateTime)dte_end.EditValue).ToList());
                        if (triggers.Count > 0) triggersmaxIndex = triggers.Max(n => n.id);
                        grid_SchedulerLog.DataSource = jobLog;
                        XtraGridHelper.SetGridColumns(gridView_SchedulerLog, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "sched_logId", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称", Width = 100  },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称", Width = 150  },
                            new GridViewColumn { ColumnName = "success", Caption="是否成功" },
                            new GridViewColumn { ColumnName = "update_time", Caption="执行时间", Width = 130  },
                            new GridViewColumn { ColumnName = "description", Caption="描述", Width = 350  }
                        });
                        gridView_SchedulerLog.OptionsBehavior.Editable = false;
                    }
                    break;
            }
        }
        #endregion

        #region 按钮事件

        private void NavBar_schedulerLog_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 3;
        }

        private void NavBar_schedulerSet_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 2;
        }

        private void NavBar_scheduleJob_details_triggers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 1;
        }

        private void NavBar_scheduleJob_details_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 0;
        }

        private void gridDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                detailsmaxIndex += 1;
                var row = new ScheduleJob_Details { id = detailsmaxIndex, is_durable = false, platformMonitoring = false };
                if (bll.SaveScheduleDetails(row))
                {
                    details.Add(row);
                }
                else
                {
                    XtraMessageBox.Show("数据添加失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = details.ElementAt(gridView2.FocusedRowHandle);
                    if (bll.DeleteScheduleDetails(row.id))
                    {
                        details.RemoveAt(gridView2.FocusedRowHandle);
                    }
                    else
                    {
                        XtraMessageBox.Show("数据删除失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridTrigger_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                triggersmaxIndex += 1;
                var row = new ScheduleJob_Details_Triggers { id = triggersmaxIndex, trigger_type = "cron" };
                if (bll.SaveScheduleDetailsTriggers(row))
                {
                    triggers.Add(row);
                }
                else
                {
                    XtraMessageBox.Show("数据添加失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var row = triggers.ElementAt(gridView3.FocusedRowHandle);
                    if (bll.DeleteScheduleDetailsTriggers(row.id))
                    {
                        triggers.RemoveAt(gridView3.FocusedRowHandle);
                    }
                    else
                    {
                        XtraMessageBox.Show("数据删除失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            var row = jobStatus.ElementAt(gridView_SchedulerSet.FocusedRowHandle);
            pcScheduler.PauseTrigger(JobHelper.GetTriggerKey(new ScheduleJob_Details_Triggers { sched_name = row.sched_name, job_name = row.job_name, trigger_name = row.trigger_name, trigger_group = row.trigger_group }));
            BandingData("ScheduleSet");
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            var row = jobStatus.ElementAt(gridView_SchedulerSet.FocusedRowHandle);
            pcScheduler.ResumeTrigger(JobHelper.GetTriggerKey(new ScheduleJob_Details_Triggers { sched_name = row.sched_name, job_name = row.job_name, trigger_name = row.trigger_name, trigger_group = row.trigger_group }));
            BandingData("ScheduleSet");
        }

        private void Sbtn_refresh_Click(object sender, EventArgs e)
        {
            BandingData("ScheduleLog");
        }

        private void Sbtn_delete_Click(object sender, EventArgs e)
        {
            if (dte_start.EditValue == null || dte_end.EditValue == null)
            {
                XtraMessageBox.Show("请选择开始时间和结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (XtraMessageBox.Show("数据删除无法恢复，是否删除指定日期的数据？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (bll.DeleteScheduleJobLog((DateTime)dte_start.EditValue, (DateTime)dte_end.EditValue))
                {
                    BandingData("ScheduleLog");
                    XtraMessageBox.Show("数据删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    XtraMessageBox.Show("数据删除失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}