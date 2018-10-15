using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Filters
{
    public class BaseFilter<TID>
    {
        public BaseFilter()
        {
            PageSize = 0;
            CurrentPage = 0;
        }

        public TID Id { get; set; }
        public DateTime? FechaBaja { set; get; }
        public string MultiColumnSearchText { get; set; }         
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
