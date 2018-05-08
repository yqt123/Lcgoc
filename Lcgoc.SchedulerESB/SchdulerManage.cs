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
        #endregion

        #region 初始化
        public SchdulerManage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            navBar_scheduleJob_details.LinkClicked += NavBar_scheduleJob_details_LinkClicked;
            navBar_scheduleJob_details_triggers.LinkClicked += NavBar_scheduleJob_details_triggers_LinkClicked;

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
                index == 1 ? "ScheduleDetailsTriggers" : ""
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
                        gridView2.Columns[0].OptionsColumn.AllowEdit = false;
                        gridView2.BestFitColumns();
                    }
                    break;
                case "ScheduleDetailsTriggers":
                    {
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
                var row = new ScheduleJob_Details { id = detailsmaxIndex, is_durable = true };
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
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                if (XtraMessageBox.Show("数据删除无法恢复，是否删除？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
    }
}