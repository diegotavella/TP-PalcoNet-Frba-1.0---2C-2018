using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Interfaces
{
    public interface IRemovableEntity
    {
        DateTimeOffset? FechaBaja { set; get; }
    }
}
