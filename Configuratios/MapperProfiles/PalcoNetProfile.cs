using AutoMapper;
using PalcoNet.Dtos;
using PalcoNet.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Configuratios.MapperProfiles
{
    public class PalcoNetProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<RolDto, Rol>().ReverseMap();
            CreateMap<FuncionalidadDto, Funcionalidad>().ReverseMap();
        }
    }
}
