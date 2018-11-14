using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos
{
    public class BaseDto<TID>
    {
        public TID Id { get; set; }
        public DateTime FechaBaja { set; get; }
    }
}
