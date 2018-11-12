using PalcoNet.Infraestructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Extensions
{
    public static class LoggerExtensions
    {
        public static void Debug(this ILogger logger, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Debug, null, null, messageFormat, messageArgs);
        }

        public static void Debug(this ILogger logger, Exception exception, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Debug, exception, null, messageFormat, messageArgs);
        }

        public static void Info(this ILogger logger, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Information, null, null, messageFormat, messageArgs);
        }

        public static void Info(this ILogger logger, Exception exception, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Information, exception, null, messageFormat, messageArgs);
        }

        public static void Warn(this ILogger logger, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Warning, null, null, messageFormat, messageArgs);
        }

        public static void Warn(this ILogger logger, Exception exception, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Warning, exception, null, messageFormat, messageArgs);
        }

        public static void Error(this ILogger logger, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Error, null, null, messageFormat, messageArgs);
        }

        public static void Error(this ILogger logger, Exception exception, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Error, exception, null, messageFormat, messageArgs);
        }

        public static void Error(this ILogger logger, Exception exception)
        {
            logger.Log(LogEventType.Error, exception, null, null, null);
        }

        public static void Fatal(this ILogger logger, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Fatal, null, null, messageFormat, messageArgs);
        }

        public static void Fatal(this ILogger logger, Exception exception, string messageFormat, params object[] messageArgs)
        {
            logger.Log(LogEventType.Fatal, exception, null, messageFormat, messageArgs);
        }
    }
}
