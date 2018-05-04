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

namespace Lcgoc.Scheduler
{
    public partial class SchdulerManage : DevExpress.XtraEditors.XtraForm
    {
        #region 声明
        BindingList<ScheduleJob> schedule = new BindingList<ScheduleJob>();
        BindingList<ScheduleJob_Details> details = new BindingList<ScheduleJob_Details>();
        BindingList<ScheduleJob_Details_Triggers> triggers = new BindingList<ScheduleJob_Details_Triggers>();
        ScheduleBLL bll = new ScheduleBLL();

        bool scheduleChange = false;
        bool detailsChange = false;
        bool triggersChange = false;

        int schedulemaxIndex = 0;
        int detailsmaxIndex = 0;
        int triggersmaxIndex = 0;
        #endregion

        #region 初始化
        public SchdulerManage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            gridView1.OptionsView.ShowGroupPanel = false;
            navBar_scheduleJob.LinkClicked += NavBar_scheduleJob_LinkClicked;
            navBar_scheduleJob_details.LinkClicked += NavBar_scheduleJob_details_LinkClicked;
            navBar_scheduleJob_details_triggers.LinkClicked += NavBar_scheduleJob_details_triggers_LinkClicked;
            sbtn_save.Click += sbtn_save_Click;

            tabPane1.SelectedPageIndexChanged += TabPane1_SelectedPageIndexChanged;
            tabPane1.SelectedPageIndex = 0;

            gridView1.CellValueChanged += GridView1_CellValueChanged;
            gridView2.CellValueChanged += GridView2_CellValueChanged;
            gridView3.CellValueChanged += GridView3_CellValueChanged;
        }
        #endregion

        #region 数据
        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            triggersChange = true;
        }

        private void GridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            detailsChange = true;
        }

        private void GridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            scheduleChange = true;
        }

        private void TabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            var index = ((DevExpress.XtraBars.Navigation.TabPane)sender).SelectedPageIndex;
            BandingData(
                index == 0 ? "Schedule" :
                index == 1 ? "ScheduleDetails" :
                index == 2 ? "ScheduleDetailsTriggers" : ""
                );
        }

        void BandingData(string name)
        {
            switch (name)
            {
                case "Schedule":
                    {
                        scheduleChange = false;
                        schedule = new BindingList<ScheduleJob>(bll.QuerySchedule().ToList());
                        if (schedule.Count > 0) schedulemaxIndex = schedule.Max(n => n.id);
                        gridMain.DataSource = schedule;
                        gridView1.Columns[0].OptionsColumn.AllowEdit = false;
                        gridView1.BestFitColumns();
                    }
                    break;
                case "ScheduleDetails":
                    {
                        detailsChange = false;
                        details = new BindingList<ScheduleJob_Details>(bll.QueryScheduleDetails().ToList());
                        if (details.Count > 0) detailsmaxIndex = details.Max(n => n.id);
                        gridDetail.DataSource = details;
                        gridView2.Columns[0].OptionsColumn.AllowEdit = false;
                        gridView2.BestFitColumns();
                    }
                    break;
                case "ScheduleDetailsTriggers":
                    {
                        triggersChange = false;
                        triggers = new BindingList<ScheduleJob_Details_Triggers>(bll.QueryScheduleDetailsTriggers().ToList());
                        if (triggers.Count > 0) triggersmaxIndex = triggers.Max(n => n.id);
                        gridTrigger.DataSource = triggers;
                        gridView3.Columns[0].OptionsColumn.AllowEdit = false;
                        gridView3.BestFitColumns();
                    }
                    break;
            }
        }

        #endregion

        #region 按钮事件
        private void NavBar_scheduleJob_details_triggers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 2;
        }

        private void NavBar_scheduleJob_details_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 1;
        }

        private void NavBar_scheduleJob_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            tabPane1.SelectedPageIndex = 0;
        }

        private void gridMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                schedulemaxIndex += 1;
                var row = new ScheduleJob { id = schedulemaxIndex, allowUsed = false, writeDBLog = true, writeTxtLog = true };
                if (bll.ScheduleAdd(row))
                {
                    schedule.Add(row);
                }
                else
                {
                    XtraMessageBox.Show("数据添加失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var row = schedule.ElementAt(gridView1.FocusedRowHandle);
                    if (bll.ScheduleDelete(row.id))
                    {
                        schedule.RemoveAt(gridView1.FocusedRowHandle);
                    }
                    else
                    {
                        XtraMessageBox.Show("数据删除失败？", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridDetail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                detailsmaxIndex += 1;
                details.Add(new ScheduleJob_Details { id = detailsmaxIndex, is_durable = true });
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    var row = details.ElementAt(gridView2.FocusedRowHandle);
                    details.Remove(row);
                }
            }
        }

        private void gridTrigger_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                triggersmaxIndex += 1;
                triggers.Add(new ScheduleJob_Details_Triggers { id = triggersmaxIndex, trigger_type = "cron" });
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    triggers.RemoveAt(gridView3.FocusedRowHandle);
                }
            }
        }

        void sbtn_save_Click(object sender, EventArgs e)
        {
            //if (sdk.SaveScheduleJob(schedule))
            //{
            //    XtraMessageBox.Show("保存成功", "系统提示", MessageBoxButtons.OK);
            //}

        }

        #endregion
    }
}