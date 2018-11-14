using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos.Responses
{
    public class Response<T> where T : class, new()
    {
        public Response()
        {
            Result = new Result();
            Data = new T();
        }
        public Result Result { set; get; }
        public T Data { set; get; }
    }
}
