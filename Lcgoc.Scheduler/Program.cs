using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;

namespace Lcgoc.Scheduler
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Application.Run(new SchedulerMain());
        }

        /// <summary>
        /// 程序报错处理方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string errorMsg = "程序运行过程中发生错误，错误信息如下:" + System.Environment.NewLine;
            errorMsg += e.Exception.Message + System.Environment.NewLine;
            errorMsg += System.Environment.NewLine;
            errorMsg += "发生错误的程序集为:" + System.Environment.NewLine;
            errorMsg += e.Exception.Source + System.Environment.NewLine;
            errorMsg += System.Environment.NewLine;
            errorMsg += "发生错误的具体位置为:" + System.Environment.NewLine;
            errorMsg += e.Exception.StackTrace;
            XtraMessageBox.Show(errorMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
