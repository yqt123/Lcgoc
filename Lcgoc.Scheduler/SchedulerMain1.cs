using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lcgoc.Scheduler
{
    public partial class SchedulerMain1 : Form
    {
        #region 声明

        /// <summary>
        /// 调度作业
        /// </summary>
        public Scheduler pcScheduler = null;

        public bool isRuning = false;

        #endregion

        #region 初始化

        public SchedulerMain1()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button3.Click += button3_Click;
            this.button4.Click += button4_Click;
            this.FormClosing += SchedulerMain_FormClosing;
        }

        void button4_Click(object sender, EventArgs e)
        {
            if (pcScheduler != null) pcScheduler.PauseAll();
        }

        void button3_Click(object sender, EventArgs e)
        {
            if (pcScheduler != null) pcScheduler.ResumeAll();
        }

        void SchedulerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pcScheduler != null) pcScheduler.Shutdown();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            pcScheduler = Scheduler.Create();
            if (pcScheduler != null) pcScheduler.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pcScheduler != null) pcScheduler.Shutdown();
        }
    }
}
