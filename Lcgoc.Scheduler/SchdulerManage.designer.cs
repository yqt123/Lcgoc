namespace Lcgoc.Scheduler
{
    partial class SchdulerManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchdulerManage));
            this.gridSchedule = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gridDetails = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gridTriggers = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.sbtn_ScheduleDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_ScheduleSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_ScheduleAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.sbtn_DetailsSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_DetailsDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_DetailsAdd = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.sbtn_TriggersSave = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_TriggersDel = new DevExpress.XtraEditors.SimpleButton();
            this.sbtn_TriggersAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTriggers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridSchedule
            // 
            this.gridSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSchedule.Location = new System.Drawing.Point(2, 2);
            this.gridSchedule.MainView = this.gridView1;
            this.gridSchedule.Name = "gridSchedule";
            this.gridSchedule.Size = new System.Drawing.Size(269, 523);
            this.gridSchedule.TabIndex = 0;
            this.gridSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridSchedule;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(273, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 562);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // gridDetails
            // 
            this.gridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetails.Location = new System.Drawing.Point(2, 2);
            this.gridDetails.MainView = this.gridView2;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.Size = new System.Drawing.Size(502, 283);
            this.gridDetails.TabIndex = 2;
            this.gridDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridDetails;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(278, 322);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(506, 5);
            this.splitterControl2.TabIndex = 3;
            this.splitterControl2.TabStop = false;
            // 
            // gridTriggers
            // 
            this.gridTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTriggers.Location = new System.Drawing.Point(2, 2);
            this.gridTriggers.MainView = this.gridView3;
            this.gridTriggers.Name = "gridTriggers";
            this.gridTriggers.Size = new System.Drawing.Size(502, 196);
            this.gridTriggers.TabIndex = 4;
            this.gridTriggers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridTriggers;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridSchedule);
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(273, 562);
            this.panelControl1.TabIndex = 5;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.sbtn_ScheduleDel);
            this.panelControl4.Controls.Add(this.sbtn_ScheduleSave);
            this.panelControl4.Controls.Add(this.sbtn_ScheduleAdd);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(2, 525);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(269, 35);
            this.panelControl4.TabIndex = 1;
            // 
            // sbtn_ScheduleDel
            // 
            this.sbtn_ScheduleDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_ScheduleDel.Location = new System.Drawing.Point(189, 5);
            this.sbtn_ScheduleDel.Name = "sbtn_ScheduleDel";
            this.sbtn_ScheduleDel.Size = new System.Drawing.Size(75, 23);
            this.sbtn_ScheduleDel.TabIndex = 0;
            this.sbtn_ScheduleDel.Text = "删除";
            // 
            // sbtn_ScheduleSave
            // 
            this.sbtn_ScheduleSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_ScheduleSave.Location = new System.Drawing.Point(27, 5);
            this.sbtn_ScheduleSave.Name = "sbtn_ScheduleSave";
            this.sbtn_ScheduleSave.Size = new System.Drawing.Size(75, 23);
            this.sbtn_ScheduleSave.TabIndex = 0;
            this.sbtn_ScheduleSave.Text = "保存";
            // 
            // sbtn_ScheduleAdd
            // 
            this.sbtn_ScheduleAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_ScheduleAdd.Location = new System.Drawing.Point(108, 5);
            this.sbtn_ScheduleAdd.Name = "sbtn_ScheduleAdd";
            this.sbtn_ScheduleAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtn_ScheduleAdd.TabIndex = 0;
            this.sbtn_ScheduleAdd.Text = "新增";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gridDetails);
            this.panelControl2.Controls.Add(this.panelControl5);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(278, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(506, 322);
            this.panelControl2.TabIndex = 6;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.sbtn_DetailsSave);
            this.panelControl5.Controls.Add(this.sbtn_DetailsDel);
            this.panelControl5.Controls.Add(this.sbtn_DetailsAdd);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl5.Location = new System.Drawing.Point(2, 285);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(502, 35);
            this.panelControl5.TabIndex = 3;
            // 
            // sbtn_DetailsSave
            // 
            this.sbtn_DetailsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_DetailsSave.Location = new System.Drawing.Point(255, 6);
            this.sbtn_DetailsSave.Name = "sbtn_DetailsSave";
            this.sbtn_DetailsSave.Size = new System.Drawing.Size(75, 23);
            this.sbtn_DetailsSave.TabIndex = 3;
            this.sbtn_DetailsSave.Text = "保存";
            // 
            // sbtn_DetailsDel
            // 
            this.sbtn_DetailsDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_DetailsDel.Location = new System.Drawing.Point(417, 6);
            this.sbtn_DetailsDel.Name = "sbtn_DetailsDel";
            this.sbtn_DetailsDel.Size = new System.Drawing.Size(75, 23);
            this.sbtn_DetailsDel.TabIndex = 1;
            this.sbtn_DetailsDel.Text = "删除";
            // 
            // sbtn_DetailsAdd
            // 
            this.sbtn_DetailsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_DetailsAdd.Location = new System.Drawing.Point(336, 6);
            this.sbtn_DetailsAdd.Name = "sbtn_DetailsAdd";
            this.sbtn_DetailsAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtn_DetailsAdd.TabIndex = 2;
            this.sbtn_DetailsAdd.Text = "新增";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridTriggers);
            this.panelControl3.Controls.Add(this.panelControl6);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(278, 327);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(506, 235);
            this.panelControl3.TabIndex = 7;
            // 
            // panelControl6
            // 
            this.panelControl6.Controls.Add(this.sbtn_TriggersSave);
            this.panelControl6.Controls.Add(this.sbtn_TriggersDel);
            this.panelControl6.Controls.Add(this.sbtn_TriggersAdd);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl6.Location = new System.Drawing.Point(2, 198);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(502, 35);
            this.panelControl6.TabIndex = 5;
            // 
            // sbtn_TriggersSave
            // 
            this.sbtn_TriggersSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_TriggersSave.Location = new System.Drawing.Point(255, 5);
            this.sbtn_TriggersSave.Name = "sbtn_TriggersSave";
            this.sbtn_TriggersSave.Size = new System.Drawing.Size(75, 23);
            this.sbtn_TriggersSave.TabIndex = 3;
            this.sbtn_TriggersSave.Text = "保存";
            // 
            // sbtn_TriggersDel
            // 
            this.sbtn_TriggersDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_TriggersDel.Location = new System.Drawing.Point(417, 5);
            this.sbtn_TriggersDel.Name = "sbtn_TriggersDel";
            this.sbtn_TriggersDel.Size = new System.Drawing.Size(75, 23);
            this.sbtn_TriggersDel.TabIndex = 1;
            this.sbtn_TriggersDel.Text = "删除";
            // 
            // sbtn_TriggersAdd
            // 
            this.sbtn_TriggersAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_TriggersAdd.Location = new System.Drawing.Point(336, 5);
            this.sbtn_TriggersAdd.Name = "sbtn_TriggersAdd";
            this.sbtn_TriggersAdd.Size = new System.Drawing.Size(75, 23);
            this.sbtn_TriggersAdd.TabIndex = 2;
            this.sbtn_TriggersAdd.Text = "新增";
            // 
            // SchdulerManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SchdulerManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "作业配置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gridSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTriggers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraGrid.GridControl gridDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraGrid.GridControl gridTriggers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraEditors.PanelControl panelControl6;
        private DevExpress.XtraEditors.SimpleButton sbtn_ScheduleDel;
        private DevExpress.XtraEditors.SimpleButton sbtn_ScheduleAdd;
        private DevExpress.XtraEditors.SimpleButton sbtn_DetailsDel;
        private DevExpress.XtraEditors.SimpleButton sbtn_DetailsAdd;
        private DevExpress.XtraEditors.SimpleButton sbtn_TriggersDel;
        private DevExpress.XtraEditors.SimpleButton sbtn_TriggersAdd;
        private DevExpress.XtraEditors.SimpleButton sbtn_ScheduleSave;
        private DevExpress.XtraEditors.SimpleButton sbtn_DetailsSave;
        private DevExpress.XtraEditors.SimpleButton sbtn_TriggersSave;
    }
}