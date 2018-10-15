using AutoMapper;
using PalcoNet.Dtos;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.App_Start
{
    public static class BootStrapper
    {
        public static void Configuration()
        {
            BootStrapper.ConfigureMapping();
        }

        public static void ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<PalcoNetProfile>();
                cfg.CreateMap<UsuarioDto, Usuario>().ReverseMap();
            });

            config.AssertConfigurationIsValid();
            Mapper.Initialize(cfg => cfg.CreateMap<UsuarioDto, Usuario>().ReverseMap());


            //Container.Inject<IMapper>(config.CreateMapper());
        }

        public static void ConfigureContainer()
        {

        }
    }
}
