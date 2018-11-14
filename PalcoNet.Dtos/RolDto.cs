using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Dtos
{
    public class RolDto : BaseDto<int>
    {
        public RolDto()
        {
            Funcionalidades = new List<FuncionalidadDto>();
        }
        public string Nombre { set; get; }
        public IList<FuncionalidadDto> Funcionalidades { set; get; }
    }
}
