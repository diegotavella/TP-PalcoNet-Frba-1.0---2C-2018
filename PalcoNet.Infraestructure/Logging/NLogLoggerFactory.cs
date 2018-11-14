using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Logging
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        public ILogger Get<TSource>() where TSource : class
        {
            return Get(typeof(TSource));
        }

        public ILogger Get(Type sourceType)
        {
            var logger = LogManager.GetLogger(sourceType.FullName);
            return new NLogLogger(logger);
        }
    }
}
