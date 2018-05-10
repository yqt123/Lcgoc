using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Lcgoc.SchedulerESB
{
    public partial class SchedulerMain : DevExpress.XtraEditors.XtraForm
    {
        #region 声明
        private Point mPoint = new Point();
        /// <summary>
        /// 是否在运行
        /// </summary>
        bool isRuning = false;
        /// <summary>
        /// 调度作业
        /// </summary>
        public Scheduler pcScheduler = null;
        #endregion

        public SchedulerMain()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.panelControl1.MouseDown += panelControl1_MouseDown;
            this.panelControl1.MouseMove += panelControl1_MouseMove;

            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            this.btn_run.Click += btn_run_Click;
        }

        #region 拖拽
        void panelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }

        void panelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }
        #endregion

        #region 最小托盘
        void sbtn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void sbtn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = true;
            }
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            //激活窗体并给予它焦点
            this.Activate();
            //任务栏区显示图标
            this.ShowInTaskbar = true;
            //托盘区图标隐藏
            notifyIcon1.Visible = true;
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                notifyIcon1.Visible = false;
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
        }

        #endregion

        private void XtraForm1_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void XtraForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (XtraMessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (pcScheduler != null) pcScheduler.Shutdown();
                notifyIcon1.Visible = false;
                // 关闭所有的线程
                this.Dispose();
                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (isRuning)
            {
                if (pcScheduler != null)
                {
                    pcScheduler.PauseAll();
                }
                this.btn_run.BackgroundImage = global::Lcgoc.SchedulerESB.Properties.Resources.start;
                this.lb_status.Text = "已停止";
                isRuning = false;
            }
            else
            {
                if (pcScheduler == null)
                {
                    pcScheduler = Scheduler.Create();
                    pcScheduler.Start();
                }
                else
                {
                    pcScheduler.ResumeAll();
                }
                this.btn_run.BackgroundImage = global::Lcgoc.SchedulerESB.Properties.Resources.stop;
                this.lb_status.Text = "正在作业...";
                isRuning = true;
            }
        }
        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_manage_Click(object sender, EventArgs e)
        {
            SchdulerManage frm = new SchdulerManage(pcScheduler);
            //frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }
    }
}