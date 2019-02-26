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

        private void WriteEvent(string text, Exception ex, EventLogEntryType eventLogEntryType)
        {
            CreateEventSource();

            if (ex != null)
            {
                text += Environment.NewLine + Environment.NewLine + formatException(ex);
            }

            using (EventLog eventLog = new EventLog(logName, machineName, source))
            {
                eventLog.WriteEntry(text.Trim(Environment.NewLine.ToCharArray()), eventLogEntryType);
            }
        }

        [Obsolete("Only for debugging. For release use Logging.Info(string, Exception)")]
        public void Debug(string text, Exception ex = null)
        {
#if DEBUG
            WriteEvent(text, ex, EventLogEntryType.Information);
#endif
        }

        public void Info(string text, Exception ex = null)
        {
            WriteEvent(text, ex, EventLogEntryType.Information);
        }
        public void Info(Exception ex)
        {
            Info(string.Empty, ex);
        }

        public void Warn(string text, Exception ex = null)
        {
            WriteEvent(text, ex, EventLogEntryType.Warning);
        }
        public void Warn(Exception ex)
        {
            Warn(string.Empty, ex);
        }

        public void Error(string text, Exception ex = null)
        {
            WriteEvent(text, ex, EventLogEntryType.Error);
        }
        public void Error(Exception ex)
        {
            Error(string.Empty, ex);
        }

        private string formatException(Exception ex)
        {
            return ex.StackTrace + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + ex.Source;
        }
    }
}
