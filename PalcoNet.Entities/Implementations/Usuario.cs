using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Implementations
{
    public class Usuario : RemovableBaseEntity<Int64>
    {
        public Usuario()
        {
            Roles = new List<Rol>();
        }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool Inhabilitado { set; get; }
        public List<Rol> Roles { set; get; }
    }
}
