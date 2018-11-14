using PalcoNet.Infraestructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos.Responses
{
    public class Result
    {
        public Result()
        {
            HasErrors = false;
            Messages = new List<string>();
        }

        public bool HasErrors { set; get; }
        public List<string> Messages { set; get; }

        public PalcoNetException Exception { get; set; }
    }
}
