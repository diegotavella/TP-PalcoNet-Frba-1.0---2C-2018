using AutoMapper;
using PalcoNet.Business.Implementations;
using PalcoNet.Configuratios.MapperProfiles;
using PalcoNet.Dtos;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Repositories;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PalcoNet.App_Start
{
    public class BootStrapper
    {
        protected readonly IUnityContainer _container = new UnityContainer();
        private static BootStrapper _instance = null;

        public static void Configuration()
        {
            if (_instance == null)
                _instance = new BootStrapper();

            _instance.ConfigureMapping();
            _instance.ConfigureContainer();
            _instance.ConfigureLogging();
        }

        /// <summary>
        /// Mapeos entities -> dtos
        /// dtos -> entities
        /// </summary>
        protected void ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PalcoNetProfile>();
            });

            config.AssertConfigurationIsValid();
            //Mapper.Initialize(cfg => cfg.CreateMap<UsuarioDto, Usuario>().ReverseMap());

            _container.RegisterInstance<IMapper>(config.CreateMapper());
        }


        protected void ConfigureContainer()
        {
            _container.RegisterType<IUnitOfWork, PalcoNetContext>();
            _container.Resolve<UsuarioBusiness>();

            //var assemblies = AllClases

            //_container.RegisterType(
            
            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        protected void ConfigureLogging()
        {
            var configurer = _container.Resolve<ILoggingConfigurer>();
            configurer.Configure();
        }
    }
}
