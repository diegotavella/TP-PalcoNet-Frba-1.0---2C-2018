using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos
{
    public class FuncionalidadDto : BaseDto<int>
    {
        public FuncionalidadDto()
        {
            Roles = new List<RolDto>();
        }
        public string Nombre { set; get; }
        public IList<RolDto> Roles { set; get; }
    }
}
