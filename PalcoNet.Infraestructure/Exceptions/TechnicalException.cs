using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Exceptions
{
    public class TechnicalException : PalcoNetException
    {
        public TechnicalException() : base() { }

        public TechnicalException(string message) : base(message) { }

        public TechnicalException(string message, Exception innerException) : base(message, innerException) { }
    }
}
