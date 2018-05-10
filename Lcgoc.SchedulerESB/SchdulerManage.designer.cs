﻿namespace Lcgoc.SchedulerESB
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
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBar_scheduleJob_details = new DevExpress.XtraNavBar.NavBarItem();
            this.navBar_scheduleJob_details_triggers = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNav_scheduleJob_details = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNav_scheduleJob_details_triggers = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBar_schedulerSet = new DevExpress.XtraNavBar.NavBarItem();
            this.tabNav_schedulerSet = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridTrigger = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_SchedulerSet = new DevExpress.XtraGrid.GridControl();
            this.gridView_SchedulerSet = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNav_scheduleJob_details.SuspendLayout();
            this.tabNav_scheduleJob_details_triggers.SuspendLayout();
            this.tabNav_schedulerSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_SchedulerSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SchedulerSet)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(273, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 562);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.navBarControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(273, 562);
            this.panelControl1.TabIndex = 5;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBar_scheduleJob_details,
            this.navBar_scheduleJob_details_triggers,
            this.navBar_schedulerSet});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 269;
            this.navBarControl1.Size = new System.Drawing.Size(269, 558);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "作业配置";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBar_scheduleJob_details),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBar_scheduleJob_details_triggers)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBar_scheduleJob_details
            // 
            this.navBar_scheduleJob_details.Caption = "作业调度明细";
            this.navBar_scheduleJob_details.ImageOptions.SmallImage = global::Lcgoc.SchedulerESB.Properties.Resources.Organizer;
            this.navBar_scheduleJob_details.Name = "navBar_scheduleJob_details";
            // 
            // navBar_scheduleJob_details_triggers
            // 
            this.navBar_scheduleJob_details_triggers.Caption = "作业调度触发器";
            this.navBar_scheduleJob_details_triggers.ImageOptions.SmallImage = global::Lcgoc.SchedulerESB.Properties.Resources.Organizer;
            this.navBar_scheduleJob_details_triggers.Name = "navBar_scheduleJob_details_triggers";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tabPane1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(278, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(506, 562);
            this.panelControl2.TabIndex = 6;
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNav_scheduleJob_details);
            this.tabPane1.Controls.Add(this.tabNav_scheduleJob_details_triggers);
            this.tabPane1.Controls.Add(this.tabNav_schedulerSet);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(2, 2);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNav_scheduleJob_details,
            this.tabNav_scheduleJob_details_triggers,
            this.tabNav_schedulerSet});
            this.tabPane1.RegularSize = new System.Drawing.Size(502, 558);
            this.tabPane1.SelectedPage = this.tabNav_scheduleJob_details;
            this.tabPane1.Size = new System.Drawing.Size(502, 558);
            this.tabPane1.TabIndex = 2;
            // 
            // tabNav_scheduleJob_details
            // 
            this.tabNav_scheduleJob_details.Caption = "作业调度明细";
            this.tabNav_scheduleJob_details.Controls.Add(this.gridDetail);
            this.tabNav_scheduleJob_details.Controls.Add(this.panelControl4);
            this.tabNav_scheduleJob_details.Name = "tabNav_scheduleJob_details";
            this.tabNav_scheduleJob_details.Size = new System.Drawing.Size(484, 512);
            // 
            // tabNav_scheduleJob_details_triggers
            // 
            this.tabNav_scheduleJob_details_triggers.Caption = "作业调度触发器";
            this.tabNav_scheduleJob_details_triggers.Controls.Add(this.gridTrigger);
            this.tabNav_scheduleJob_details_triggers.Controls.Add(this.panelControl3);
            this.tabNav_scheduleJob_details_triggers.Name = "tabNav_scheduleJob_details_triggers";
            this.tabNav_scheduleJob_details_triggers.Size = new System.Drawing.Size(484, 512);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "作业管理";
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBar_schedulerSet)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBar_schedulerSet
            // 
            this.navBar_schedulerSet.Caption = "运行控制";
            this.navBar_schedulerSet.ImageOptions.SmallImage = global::Lcgoc.SchedulerESB.Properties.Resources.Organizer;
            this.navBar_schedulerSet.Name = "navBar_schedulerSet";
            // 
            // tabNav_schedulerSet
            // 
            this.tabNav_schedulerSet.Caption = "运行控制";
            this.tabNav_schedulerSet.Controls.Add(this.grid_SchedulerSet);
            this.tabNav_schedulerSet.Name = "tabNav_schedulerSet";
            this.tabNav_schedulerSet.Size = new System.Drawing.Size(484, 512);
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.labelControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 482);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(484, 30);
            this.panelControl4.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(139, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "insert新增，delete删除";
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.gridView2;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(484, 482);
            this.gridDetail.TabIndex = 5;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridDetail;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 482);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(484, 30);
            this.panelControl3.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(139, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "insert新增，delete删除";
            // 
            // gridTrigger
            // 
            this.gridTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrigger.Location = new System.Drawing.Point(0, 0);
            this.gridTrigger.MainView = this.gridView3;
            this.gridTrigger.Name = "gridTrigger";
            this.gridTrigger.Size = new System.Drawing.Size(484, 482);
            this.gridTrigger.TabIndex = 6;
            this.gridTrigger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridTrigger;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // grid_SchedulerSet
            // 
            this.grid_SchedulerSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_SchedulerSet.Location = new System.Drawing.Point(0, 0);
            this.grid_SchedulerSet.MainView = this.gridView_SchedulerSet;
            this.grid_SchedulerSet.Name = "grid_SchedulerSet";
            this.grid_SchedulerSet.Size = new System.Drawing.Size(484, 512);
            this.grid_SchedulerSet.TabIndex = 6;
            this.grid_SchedulerSet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_SchedulerSet});
            // 
            // gridView_SchedulerSet
            // 
            this.gridView_SchedulerSet.GridControl = this.grid_SchedulerSet;
            this.gridView_SchedulerSet.Name = "gridView_SchedulerSet";
            this.gridView_SchedulerSet.OptionsView.ColumnAutoWidth = false;
            this.gridView_SchedulerSet.OptionsView.ShowGroupPanel = false;
            // 
            // SchdulerManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "SchdulerManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "作业配置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNav_scheduleJob_details.ResumeLayout(false);
            this.tabNav_scheduleJob_details_triggers.ResumeLayout(false);
            this.tabNav_schedulerSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_SchedulerSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SchedulerSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBar_scheduleJob_details;
        private DevExpress.XtraNavBar.NavBarItem navBar_scheduleJob_details_triggers;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNav_scheduleJob_details;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNav_scheduleJob_details_triggers;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private DevExpress.XtraNavBar.NavBarItem navBar_schedulerSet;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNav_schedulerSet;
        private DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridTrigger;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grid_SchedulerSet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_SchedulerSet;
    }
}