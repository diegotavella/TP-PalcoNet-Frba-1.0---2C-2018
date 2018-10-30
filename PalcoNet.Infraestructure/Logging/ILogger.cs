using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Logging
{
    public interface ILogger
    {
        bool IsEnabled(LogEventType type);
        void Log(LogEventType eventType, Exception exception, IDictionary<string, object> properties, string message, params object[] messageArgs);
    }

    public enum LogEventType
    {
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Fatal = 5,
        Trace = 6
    }
}
