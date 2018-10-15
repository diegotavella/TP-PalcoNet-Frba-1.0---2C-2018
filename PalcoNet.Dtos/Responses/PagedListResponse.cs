using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos.Responses
{
    public class PagedListResponse<T>
    {   
        public PagedListResponse()
        {
            Response = new Response<List<T>>(); 
        }
        public Response<List<T>> Response { set; get; }
        public int Count { set; get; }
    }
}
