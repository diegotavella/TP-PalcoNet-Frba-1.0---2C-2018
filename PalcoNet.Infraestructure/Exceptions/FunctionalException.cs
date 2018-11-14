using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Exceptions
{
    public class FunctionalException : PalcoNetException
    {
        public FunctionalException() : base() { }

        public FunctionalException(string message) : base(message) { }

        public FunctionalException(string message, Exception innerException) : base(message, innerException) { }
    }
}
