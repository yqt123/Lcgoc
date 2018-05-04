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
            this.gridMain = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBar_scheduleJob = new DevExpress.XtraNavBar.NavBarItem();
            this.navBar_scheduleJob_details = new DevExpress.XtraNavBar.NavBarItem();
            this.navBar_scheduleJob_details_triggers = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNav_navBar_scheduleJob = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelbar = new DevExpress.XtraEditors.PanelControl();
            this.sbtn_save = new DevExpress.XtraEditors.SimpleButton();
            this.tabNav_navBar_scheduleJob_details = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNav_navBar_scheduleJob_details_triggers = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.sbtn_detailSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.sbtn_triggerSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridTrigger = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNav_navBar_scheduleJob.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelbar)).BeginInit();
            this.panelbar.SuspendLayout();
            this.tabNav_navBar_scheduleJob_details.SuspendLayout();
            this.tabNav_navBar_scheduleJob_details_triggers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMain
            // 
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.MainView = this.gridView1;
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(484, 468);
            this.gridMain.TabIndex = 0;
            this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridMain_KeyUp);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridMain;
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
            this.navBarGroup1});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBar_scheduleJob,
            this.navBar_scheduleJob_details,
            this.navBar_scheduleJob_details_triggers});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 269;
            this.navBarControl1.Size = new System.Drawing.Size(269, 558);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "作业管理";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBar_scheduleJob),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBar_scheduleJob_details),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBar_scheduleJob_details_triggers)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBar_scheduleJob
            // 
            this.navBar_scheduleJob.Caption = "scheduleJob";
            this.navBar_scheduleJob.ImageOptions.SmallImage = global::Lcgoc.Scheduler.Properties.Resources.Organizer;
            this.navBar_scheduleJob.Name = "navBar_scheduleJob";
            // 
            // navBar_scheduleJob_details
            // 
            this.navBar_scheduleJob_details.Caption = "scheduleJob_details";
            this.navBar_scheduleJob_details.ImageOptions.SmallImage = global::Lcgoc.Scheduler.Properties.Resources.Organizer;
            this.navBar_scheduleJob_details.Name = "navBar_scheduleJob_details";
            // 
            // navBar_scheduleJob_details_triggers
            // 
            this.navBar_scheduleJob_details_triggers.Caption = "scheduleJob_details_triggers";
            this.navBar_scheduleJob_details_triggers.ImageOptions.SmallImage = global::Lcgoc.Scheduler.Properties.Resources.Organizer;
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
            this.tabPane1.Controls.Add(this.tabNav_navBar_scheduleJob);
            this.tabPane1.Controls.Add(this.tabNav_navBar_scheduleJob_details);
            this.tabPane1.Controls.Add(this.tabNav_navBar_scheduleJob_details_triggers);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(2, 2);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNav_navBar_scheduleJob,
            this.tabNav_navBar_scheduleJob_details,
            this.tabNav_navBar_scheduleJob_details_triggers});
            this.tabPane1.RegularSize = new System.Drawing.Size(502, 558);
            this.tabPane1.SelectedPage = this.tabNav_navBar_scheduleJob;
            this.tabPane1.Size = new System.Drawing.Size(502, 558);
            this.tabPane1.TabIndex = 2;
            // 
            // tabNav_navBar_scheduleJob
            // 
            this.tabNav_navBar_scheduleJob.Caption = "navBar_scheduleJob";
            this.tabNav_navBar_scheduleJob.Controls.Add(this.gridMain);
            this.tabNav_navBar_scheduleJob.Controls.Add(this.panelbar);
            this.tabNav_navBar_scheduleJob.Name = "tabNav_navBar_scheduleJob";
            this.tabNav_navBar_scheduleJob.Size = new System.Drawing.Size(484, 512);
            // 
            // panelbar
            // 
            this.panelbar.Controls.Add(this.sbtn_save);
            this.panelbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbar.Location = new System.Drawing.Point(0, 468);
            this.panelbar.Name = "panelbar";
            this.panelbar.Size = new System.Drawing.Size(484, 44);
            this.panelbar.TabIndex = 1;
            // 
            // sbtn_save
            // 
            this.sbtn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_save.Location = new System.Drawing.Point(389, 5);
            this.sbtn_save.Name = "sbtn_save";
            this.sbtn_save.Size = new System.Drawing.Size(90, 33);
            this.sbtn_save.TabIndex = 0;
            this.sbtn_save.Text = "save";
            // 
            // tabNav_navBar_scheduleJob_details
            // 
            this.tabNav_navBar_scheduleJob_details.Caption = "navBar_scheduleJob_details";
            this.tabNav_navBar_scheduleJob_details.Controls.Add(this.gridDetail);
            this.tabNav_navBar_scheduleJob_details.Controls.Add(this.panelControl3);
            this.tabNav_navBar_scheduleJob_details.Name = "tabNav_navBar_scheduleJob_details";
            this.tabNav_navBar_scheduleJob_details.Size = new System.Drawing.Size(484, 512);
            // 
            // tabNav_navBar_scheduleJob_details_triggers
            // 
            this.tabNav_navBar_scheduleJob_details_triggers.Caption = "scheduleJob_details_triggers";
            this.tabNav_navBar_scheduleJob_details_triggers.Controls.Add(this.gridTrigger);
            this.tabNav_navBar_scheduleJob_details_triggers.Controls.Add(this.panelControl4);
            this.tabNav_navBar_scheduleJob_details_triggers.Name = "tabNav_navBar_scheduleJob_details_triggers";
            this.tabNav_navBar_scheduleJob_details_triggers.Size = new System.Drawing.Size(484, 512);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.sbtn_detailSave);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 468);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(484, 44);
            this.panelControl3.TabIndex = 2;
            // 
            // sbtn_detailSave
            // 
            this.sbtn_detailSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_detailSave.Location = new System.Drawing.Point(389, 5);
            this.sbtn_detailSave.Name = "sbtn_detailSave";
            this.sbtn_detailSave.Size = new System.Drawing.Size(90, 33);
            this.sbtn_detailSave.TabIndex = 0;
            this.sbtn_detailSave.Text = "save";
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.gridView2;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(484, 468);
            this.gridDetail.TabIndex = 3;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridDetail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridDetail_KeyUp);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridDetail;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.sbtn_triggerSave);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl4.Location = new System.Drawing.Point(0, 468);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(484, 44);
            this.panelControl4.TabIndex = 3;
            // 
            // sbtn_triggerSave
            // 
            this.sbtn_triggerSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtn_triggerSave.Location = new System.Drawing.Point(389, 5);
            this.sbtn_triggerSave.Name = "sbtn_triggerSave";
            this.sbtn_triggerSave.Size = new System.Drawing.Size(90, 33);
            this.sbtn_triggerSave.TabIndex = 0;
            this.sbtn_triggerSave.Text = "save";
            // 
            // gridTrigger
            // 
            this.gridTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTrigger.Location = new System.Drawing.Point(0, 0);
            this.gridTrigger.MainView = this.gridView3;
            this.gridTrigger.Name = "gridTrigger";
            this.gridTrigger.Size = new System.Drawing.Size(484, 468);
            this.gridTrigger.TabIndex = 4;
            this.gridTrigger.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.gridTrigger.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridTrigger_KeyUp);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridTrigger;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNav_navBar_scheduleJob.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelbar)).EndInit();
            this.panelbar.ResumeLayout(false);
            this.tabNav_navBar_scheduleJob_details.ResumeLayout(false);
            this.tabNav_navBar_scheduleJob_details_triggers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelbar;
        private DevExpress.XtraEditors.SimpleButton sbtn_save;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBar_scheduleJob;
        private DevExpress.XtraNavBar.NavBarItem navBar_scheduleJob_details;
        private DevExpress.XtraNavBar.NavBarItem navBar_scheduleJob_details_triggers;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNav_navBar_scheduleJob;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNav_navBar_scheduleJob_details;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNav_navBar_scheduleJob_details_triggers;
        private DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton sbtn_detailSave;
        private DevExpress.XtraGrid.GridControl gridTrigger;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton sbtn_triggerSave;
    }
}