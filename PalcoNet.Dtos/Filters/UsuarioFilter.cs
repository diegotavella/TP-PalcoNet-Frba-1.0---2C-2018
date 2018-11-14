using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Filters
{
    public class UsuarioFilter : BaseFilter<Int64>
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
