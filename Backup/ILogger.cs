using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backup
{
    interface ILogger
    {
        [Obsolete("Only for debugging. For release use ILogger.Info(string, Exception)")]
        void Debug(string text, Exception ex = null);
        void Info(string text, Exception ex = null);
        void Info(Exception ex);

        void Warn(string text, Exception ex = null);
        void Warn(Exception ex);

        void Error(string text, Exception ex = null);
        void Error(Exception ex);
    }
}
