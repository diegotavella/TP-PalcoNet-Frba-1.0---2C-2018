using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Logging
{
    public interface ILoggerFactory
    {
        ILogger Get<TSource>() where TSource : class;
        ILogger Get(Type sourceType);
    }
}
