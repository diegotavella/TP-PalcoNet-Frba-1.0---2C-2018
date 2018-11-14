using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Logging
{
    /// <summary>
    /// Exclusiva para test, dado que no se puede mockear metodos de extension
    /// se supone que todos los test usen esta y no necesiten una particular
    /// </summary>
    public class LoggerFake : ILogger
    {
        public bool IsEnabled(LogEventType type)
        {
            return true;
        }

        public void Log(LogEventType eventType, Exception exception, IDictionary<string, object> properties, string message, params object[] messageArgs)
        {
        }
    }
}
