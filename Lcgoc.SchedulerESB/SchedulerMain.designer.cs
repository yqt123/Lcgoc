namespace Lcgoc.SchedulerESB
{
    partial class SchedulerMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulerMain));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_run = new DevExpress.XtraEditors.SimpleButton();
            this.btn_manage = new DevExpress.XtraEditors.SimpleButton();
            this.btn_min = new DevExpress.XtraEditors.SimpleButton();
            this.lb_status = new DevExpress.XtraEditors.LabelControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Controls.Add(this.btn_close);
            this.panelControl1.Controls.Add(this.btn_run);
            this.panelControl1.Controls.Add(this.btn_manage);
            this.panelControl1.Controls.Add(this.btn_min);
            this.panelControl1.Controls.Add(this.lb_status);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(630, 400);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_close
            // 
            this.btn_close.AllowFocus = false;
            this.btn_close.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_close.Location = new System.Drawing.Point(592, 5);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(33, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "╳";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_run
            // 
            this.btn_run.AllowFocus = false;
            this.btn_run.BackgroundImage = global::Lcgoc.SchedulerESB.Properties.Resources.start;
            this.btn_run.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_run.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_run.Location = new System.Drawing.Point(100, 113);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(128, 128);
            this.btn_run.TabIndex = 1;
            // 
            // btn_manage
            // 
            this.btn_manage.AllowFocus = false;
            this.btn_manage.BackgroundImage = global::Lcgoc.SchedulerESB.Properties.Resources.Organizer;
            this.btn_manage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_manage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_manage.Location = new System.Drawing.Point(5, 5);
            this.btn_manage.Name = "btn_manage";
            this.btn_manage.Size = new System.Drawing.Size(33, 23);
            this.btn_manage.TabIndex = 1;
            this.btn_manage.Click += new System.EventHandler(this.btn_manage_Click);
            // 
            // btn_min
            // 
            this.btn_min.AllowFocus = false;
            this.btn_min.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_min.Location = new System.Drawing.Point(553, 5);
            this.btn_min.Name = "btn_min";
            this.btn_min.Size = new System.Drawing.Size(33, 23);
            this.btn_min.TabIndex = 1;
            this.btn_min.Text = "一";
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            // 
            // lb_status
            // 
            this.lb_status.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lb_status.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lb_status.Appearance.Options.UseBackColor = true;
            this.lb_status.Appearance.Options.UseFont = true;
            this.lb_status.Appearance.Options.UseForeColor = true;
            this.lb_status.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_status.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lb_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lb_status.Location = new System.Drawing.Point(2, 368);
            this.lb_status.Name = "lb_status";
            this.lb_status.Padding = new System.Windows.Forms.Padding(5);
            this.lb_status.Size = new System.Drawing.Size(626, 30);
            this.lb_status.TabIndex = 103;
            this.lb_status.Text = "未开始";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMenuItem,
            this.ExitMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // ShowMenuItem
            // 
            this.ShowMenuItem.Name = "ShowMenuItem";
            this.ShowMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ShowMenuItem.Text = "显示";
            this.ShowMenuItem.Click += new System.EventHandler(this.ShowMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ExitMenuItem.Text = "退出";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // SchedulerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 400);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SchedulerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XtraForm1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraForm1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.XtraForm1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem ShowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private DevExpress.XtraEditors.LabelControl lb_status;
        private DevExpress.XtraEditors.SimpleButton btn_close;
        private DevExpress.XtraEditors.SimpleButton btn_min;
        private DevExpress.XtraEditors.SimpleButton btn_manage;
        private DevExpress.XtraEditors.SimpleButton btn_run;
    }
}