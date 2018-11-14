using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Implementations
{
    public class Rol : BaseEntity<int>
    {
        public Rol()
        {
            Funcionalidades = new List<Funcionalidad>();
        }
        public string Nombre { set; get; }
        public IList<Funcionalidad> Funcionalidades { set; get; }
    }
}
