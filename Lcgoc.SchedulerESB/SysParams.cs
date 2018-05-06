using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace Lcgoc.SchedulerESB
{
    public class SysParams
    {
        public static string APIUrl = System.Configuration.ConfigurationSettings.AppSettings["APIUrl"];
        public static bool FromXML = System.Configuration.ConfigurationSettings.AppSettings["SchduleSource"] == "XML";
        public static readonly Logger logger = LogManager.GetLogger("NLogConsoleExample");
    }
}
