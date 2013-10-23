using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowsService1
{
    public partial class mups : ServiceBase
    {
        System.Diagnostics.EventLog eventLog1 = new EventLog();
        const string source_name = "mups_log_source";
        const string log_name = "mups_log";
        public mups()
        {
            InitializeComponent();
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
