using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Backup
{
    class EventLogger : ILogger
    {
        const string source = "BackupApp";
        const string logName = "BackupApp";

        private string machineName
        {
            get
            {
                return Environment.MachineName;
            }
        }

        private void CreateEventSource()
        {
            if (!EventLog.SourceExists(source, machineName))
            {
                EventLog.CreateEventSource(source, logName);
            }
        }
        public void Debug(string text)
        {
            CreateEventSource();

            using (EventLog eventLog = new EventLog(logName, machineName, source))
            {
                eventLog.WriteEntry(text, EventLogEntryType.Information);
            }
        }

        public void Warn(string text)
        {
            CreateEventSource();

            using (EventLog eventLog = new EventLog(logName, machineName, source))
            {
                eventLog.WriteEntry(text, EventLogEntryType.Warning);
            }
        }

        public void Error(string text)
        {
            CreateEventSource();

            using (EventLog eventLog = new EventLog(logName, machineName, source))
            {
                eventLog.WriteEntry(text, EventLogEntryType.Error);
            }
        }

        public void Error(string text, Exception ex)
        {
            Error(text);
            Error(ex.StackTrace);
        }
        public void Error(Exception ex)
        {
            Error(ex.StackTrace);
            Error(ex.Message);
            Error(ex.Source);
        }
    }
}
