using PalcoNet.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Implementations
{
    public abstract class RemovableBaseEntity<TID> : BaseEntity<TID>, IRemovableEntity
    {
        public DateTimeOffset? FechaBaja { get; set; }
    }
}
