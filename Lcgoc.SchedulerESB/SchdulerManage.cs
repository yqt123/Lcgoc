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

namespace Lcgoc.SchedulerESB
{
    public partial class SchdulerManage : DevExpress.XtraEditors.XtraForm
    {
        #region 声明
        BindingList<ScheduleJob_Details> details = new BindingList<ScheduleJob_Details>();
        BindingList<ScheduleJob_Details_Triggers> triggers = new BindingList<ScheduleJob_Details_Triggers>();
        ScheduleBLL bll = new ScheduleBLL();

        int schedulemaxIndex = 0;
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
            tabPane1.SelectedPageIndexChanged += TabPane1_SelectedPageIndexChanged;
            tabPane1.SelectedPageIndex = 0;
            gridView2.CellValueChanged += GridView2_CellValueChanged;
            gridView3.CellValueChanged += GridView3_CellValueChanged;
        }

        #endregion

        #region 数据
        private void GridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = details.ElementAt(gridView2.FocusedRowHandle);
            bll.ScheduleDetailsEdit(row);
        }

        private void GridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = triggers.ElementAt(gridView3.FocusedRowHandle);
            bll.ScheduleDetailsTriggersEdit(row);
        }

        private void TabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            var index = ((DevExpress.XtraBars.Navigation.TabPane)sender).SelectedPageIndex;
            BandingData(
                index == 0 ? "ScheduleDetails" :
                index == 1 ? "ScheduleDetailsTriggers" :
                index == 2 ? "ScheduleSet" : ""
                );
        }
        void BandingData(string name)
        {
            switch (name)
            {
                case "ScheduleDetails":
                    {
                        details = new BindingList<ScheduleJob_Details>(bll.QueryScheduleDetails().ToList());
                        if (details.Count > 0) detailsmaxIndex = details.Max(n => n.id);
                        gridDetail.DataSource = details;
                        RefreshGridColumns(gridView2, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "id", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称" },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称"},
                            new GridViewColumn { ColumnName = "job_group",Caption="作业组"},
                            new GridViewColumn { ColumnName = "outAssembly", Caption="调用外部程序集" },
                            new GridViewColumn { ColumnName = "job_class_name", Caption="调用类" },
                            new GridViewColumn { ColumnName = "is_durable", Caption="是否可用" },
                            new GridViewColumn { ColumnName = "description", Caption="描述" },
                            new GridViewColumn { ColumnName = "startTime", Caption="开始时间" },
                            new GridViewColumn { ColumnName = "endTime", Caption="结束时间" },
                        });
                    }
                    break;
                case "ScheduleDetailsTriggers":
                    {
                        triggers = new BindingList<ScheduleJob_Details_Triggers>(bll.QueryScheduleDetailsTriggers().ToList());
                        if (triggers.Count > 0) triggersmaxIndex = triggers.Max(n => n.id);
                        gridTrigger.DataSource = triggers;
                        RefreshGridColumns(gridView3, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "id", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称" },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称" },
                            new GridViewColumn { ColumnName = "trigger_name", Caption="触发器" },
                            new GridViewColumn { ColumnName = "trigger_group", Caption="触发器组" },
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
                        grid_SchedulerSet.DataSource = new BindingList<ScheduleJob_Status>(listScheduleJobStatus);

                        //停止按钮
                        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnStop = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
                        btnStop.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;//隐藏文字
                        //btnStop.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;//按钮样式
                        btnStop.Buttons[0].Caption = "暂停作业";
                        btnStop.ButtonClick += (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) =>
                        {
                            XtraMessageBox.Show("数据添加失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        };

                        RefreshGridColumns(gridView_SchedulerSet, columnArgs: new List<GridViewColumn> {
                            new GridViewColumn { ColumnName = "id", Caption="编号", AllowEdit = false, Width = 50 },
                            new GridViewColumn { ColumnName = "sched_name", Caption="计划名称", AllowEdit = false },
                            new GridViewColumn { ColumnName = "job_name", Caption="作业名称", AllowEdit = false },
                            new GridViewColumn { ColumnName = "job_group", Caption="作业组", AllowEdit = false },
                            new GridViewColumn { ColumnName = "trigger_name", Caption="触发器", AllowEdit = false },
                            new GridViewColumn { ColumnName = "trigger_group", Caption="触发器组", AllowEdit = false },
                            new GridViewColumn { ColumnName = "description",  Caption="描述", AllowEdit = false},
                            new GridViewColumn { ColumnName = "status", Caption="运行状态", AllowEdit = false, Width = 100},
                            new GridViewColumn { ColumnName = "btn1", Caption="暂停", IsNew = true, Width = 100,RepositoryItemButtonEdit=btnStop},
                            new GridViewColumn { ColumnName = "btn2", Caption="重新开始", IsNew = true, Width = 100},
                        });
                    }
                    break;
            }
        }

        #endregion

        #region 按钮事件

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
                var row = new ScheduleJob_Details { id = detailsmaxIndex, is_durable = false };
                if (bll.ScheduleDetailsAdd(row))
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
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var row = details.ElementAt(gridView2.FocusedRowHandle);
                    if (bll.ScheduleDetailsDelete(row.id))
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
                if (bll.ScheduleDetailsTriggersAdd(row))
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
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var row = triggers.ElementAt(gridView3.FocusedRowHandle);
                    if (bll.ScheduleDetailsTriggersDelete(row.id))
                    {
                        triggers.RemoveAt(gridView3.FocusedRowHandle);
                    }
                    else
                    {
                        XtraMessageBox.Show("数据删除失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        private void RefreshGridColumns(DevExpress.XtraGrid.Views.Grid.GridView gv, List<GridViewColumn> columnArgs = null, int? RowHeight = null)
        {
            gv.BestFitColumns();
            if (columnArgs != null)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn item in gv.Columns)
                {
                    var col = columnArgs.Where(n => n.ColumnName == item.FieldName).FirstOrDefault();
                    if (col != null)
                    {
                        item.Width = col.Width == null ? item.Width : (int)col.Width;
                        item.Caption = col.Caption == null ? item.Caption : col.Caption;
                        item.OptionsColumn.AllowEdit = col.AllowEdit == null ? item.OptionsColumn.AllowEdit : (bool)col.AllowEdit;
                        item.Visible = col.Visible == null ? item.OptionsColumn.ShowCaption : (bool)col.Visible;
                    }
                }
                foreach (GridViewColumn item in columnArgs)
                {
                    if (item.IsNew == true)
                    {
                        var col = gv.Columns.ColumnByFieldName(item.ColumnName);
                        if (col == null)
                        {
                            var colNew = new DevExpress.XtraGrid.Columns.GridColumn()
                            {
                                FieldName = item.ColumnName,
                                Caption = item.Caption,
                                Width = item.Width == null ? 50 : (int)item.Width,
                            };
                            if (item.RepositoryItemButtonEdit != null)
                            {
                                var btnEdit = item.RepositoryItemButtonEdit as DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit;
                                gv.GridControl.RepositoryItems.Add(btnEdit);
                                colNew.ColumnEdit = btnEdit;
                            }
                            gv.Columns.Add(colNew);
                        }
                    }
                }
            }
            if (RowHeight != null) gv.RowHeight = (int)RowHeight;
        }

        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit SetGridButton()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            return null;
        }
    }
}