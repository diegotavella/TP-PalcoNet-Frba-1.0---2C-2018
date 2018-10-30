using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos
{
    public class UsuarioDto : BaseDto<Int64>
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool Inhabilitado { set; get; }
    }
}
