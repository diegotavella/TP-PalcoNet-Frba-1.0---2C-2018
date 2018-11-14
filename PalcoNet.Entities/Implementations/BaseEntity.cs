using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Implementations
{
    public abstract class BaseEntity<TID>
    {
        public TID Id { get; set; }
    }
}
