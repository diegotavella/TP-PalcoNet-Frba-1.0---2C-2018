using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Logging
{
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger;
        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        public bool IsEnabled(LogEventType type)
        {
            return _logger.IsEnabled(ConvertToLogLevel(type));
        }

        public void Log(LogEventType eventType, Exception exception, IDictionary<string, object> properties, string message, params object[] messageArgs)
        {
            var level = ConvertToLogLevel(eventType);

            if (!_logger.IsEnabled(level)) return;

            var info = new LogEventInfo
            {
                Exception = exception,
                Level = level,
                Message = message,
                Parameters = messageArgs,
                LoggerName = _logger.Name,
            };

            _logger.Log(info);
        }

        public static LogLevel ConvertToLogLevel(LogEventType eventType)
        {
            switch (eventType)
            {
                case LogEventType.Debug:
                    return LogLevel.Debug;
                case LogEventType.Information:
                    return LogLevel.Info;
                case LogEventType.Warning:
                    return LogLevel.Warn;
                case LogEventType.Error:
                    return LogLevel.Error;
                case LogEventType.Fatal:
                    return LogLevel.Fatal;
                default:
                    throw new ArgumentException("LogEventType invalido", "eventType");
            }
        }
    }
}
