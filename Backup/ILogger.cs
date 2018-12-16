using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backup
{
    interface ILogger
    {
        void Debug(string text);

        void Warn(string text);

        void Error(string text);
        void Error(string text, Exception ex);
        void Error(Exception ex);
    }
}
