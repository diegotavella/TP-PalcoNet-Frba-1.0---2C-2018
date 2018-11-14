using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Filters
{
    public class BaseFilter<TID>
    {
        public TID Id { get; set; }
        public DateTime? FechaBaja { set; get; }
        public string MultiColumnSearchText { get; set; }
    }
}
