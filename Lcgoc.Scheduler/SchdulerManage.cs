using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lcgoc.Model;

namespace Lcgoc.Scheduler
{
    public partial class SchdulerManage : DevExpress.XtraEditors.XtraForm
    {
        #region 声明
        BindingList<ScheduleJob> schedule;
        BindingList<ScheduleJob_Details> details;
        BindingList<ScheduleJob_Details_Triggers> triggers;
        ScheduleSDK sdk = new ScheduleSDK();
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
            gridView2.OptionsView.ShowGroupPanel = false;
            gridView3.OptionsView.ShowGroupPanel = false;

            schedule = new BindingList<ScheduleJob>(sdk.QuerySchedule());
            details = new BindingList<ScheduleJob_Details>(sdk.QueryJobDetails());
            triggers = new BindingList<ScheduleJob_Details_Triggers>(new List<ScheduleJob_Details_Triggers>(sdk.QueryTriggers("", "")));
            this.SizeChanged += SchdulerManage_SizeChanged;

            gridSchedule.DataSource = schedule;
            gridView1.BestFitColumns();
            gridDetails.DataSource = details;
            gridView2.BestFitColumns();
            gridTriggers.DataSource = triggers;
            gridView3.BestFitColumns();

            sbtn_ScheduleAdd.Click += sbtn_ScheduleAdd_Click;
            sbtn_ScheduleDel.Click += sbtn_ScheduleDel_Click;
            sbtn_ScheduleSave.Click += sbtn_ScheduleSave_Click;

            sbtn_DetailsAdd.Click += sbtn_DetailsAdd_Click;
            sbtn_DetailsDel.Click += sbtn_DetailsDel_Click;
            sbtn_DetailsSave.Click += sbtn_DetailsSave_Click;

            sbtn_TriggersAdd.Click += sbtn_TriggersAdd_Click;
            sbtn_TriggersDel.Click += sbtn_TriggersDel_Click;
            sbtn_TriggersSave.Click += sbtn_TriggersSave_Click;
        }

        void SchdulerManage_SizeChanged(object sender, EventArgs e)
        {
            this.panelControl1.Width = this.Width / 4;
            this.panelControl2.Height = this.Height / 2;
        }

        #endregion

        #region 按钮事件
        void sbtn_ScheduleAdd_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        void sbtn_ScheduleDel_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > 0)
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        void sbtn_ScheduleSave_Click(object sender, EventArgs e)
        {
            if (sdk.SaveScheduleJob(schedule))
            {
                XtraMessageBox.Show("保存成功", "系统提示", MessageBoxButtons.OK);
            }
        }

        void sbtn_DetailsAdd_Click(object sender, EventArgs e)
        {
            gridView2.AddNewRow();
        }

        void sbtn_DetailsDel_Click(object sender, EventArgs e)
        {
            if (gridView2.FocusedRowHandle > 0)
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
        }

        void sbtn_DetailsSave_Click(object sender, EventArgs e)
        {
            if (sdk.SaveScheduleDetail(details))
            {
                XtraMessageBox.Show("保存成功", "系统提示", MessageBoxButtons.OK);
            }
        }

        void sbtn_TriggersAdd_Click(object sender, EventArgs e)
        {
            gridView3.AddNewRow();
        }

        void sbtn_TriggersDel_Click(object sender, EventArgs e)
        {
            if (gridView3.FocusedRowHandle > 0)
                gridView3.DeleteRow(gridView3.FocusedRowHandle);
        }

        void sbtn_TriggersSave_Click(object sender, EventArgs e)
        {
            if (sdk.SaveScheduleTriggers(triggers))
            {
                XtraMessageBox.Show("保存成功", "系统提示", MessageBoxButtons.OK);
            }
        }
        #endregion
    }
}