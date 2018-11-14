using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Exceptions
{
    public class PalcoNetException : Exception
    {
        public PalcoNetException() : base() { }

        public PalcoNetException(string message) : base(message) { }

        public PalcoNetException(string message, Exception innerException) : base(message, innerException) { }
    }
}
