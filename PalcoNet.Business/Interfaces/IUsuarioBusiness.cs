using PalcoNet.Dtos;
using PalcoNet.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        Response<UsuarioDto> GetByUserNamePassword(string userName, string password);
    }
}
