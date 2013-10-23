using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace WindowsService1
{
    public partial class mups : ServiceBase
    {
        System.Diagnostics.EventLog eventLog1 = new EventLog();
         string source_name=string.Empty ;
         string log_name=string.Empty ;
        public mups()
        {
            InitializeComponent();
            string assemblyPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(assemblyPath);
            source_name = cfg.AppSettings.Settings["source_name"].Value;
            log_name = cfg.AppSettings.Settings["log_name"].Value;
            if (!System.Diagnostics.EventLog.SourceExists(source_name))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    source_name, log_name);
            }
            eventLog1.Source = source_name;
            eventLog1.Log = log_name;
        }

        protected override void OnStart(string[] args)
        {
            //Debugger.Launch();
            eventLog1.WriteEntry("In OnStart");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }

        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }  
    }
}
