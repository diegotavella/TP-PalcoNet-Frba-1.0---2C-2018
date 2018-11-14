using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Implementations
{
    public class Funcionalidad : BaseEntity<int>
    {
        public Funcionalidad()
        {
            Roles = new List<Rol>();
        }
        public string Nombre { set; get; }
        public IList<Rol> Roles { set; get; }
    }
}
