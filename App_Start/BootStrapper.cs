using AutoMapper;
using PalcoNet.Business.Implementations;
using PalcoNet.Configuratios.MapperProfiles;
using PalcoNet.Dtos;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Infraestructure.Extensions;
using PalcoNet.Repositories;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using PalcoNet.Business.Interfaces;
using PalcoNet.Forms;
using PalcoNet.Login;

namespace PalcoNet.App_Start
{
    public class BootStrapper
    {
        protected IUnityContainer _container;
        private static BootStrapper _instance = null;

        public static void Configuration(IUnityContainer container)
        {
            if (_instance == null)
                _instance = new BootStrapper();

            _instance._container = container;
            _instance.ConfigureMapping();
            _instance.ConfigureContainer();
            _instance.ConfigureLogging();
            _instance.ConfigureForms();
        }

        /// <summary>
        /// Mapeos entities -> dtos
        /// dtos -> entities
        /// </summary>
        protected void ConfigureMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfilesFromAssemblyOf(GetType());
            });

            _container.RegisterInstance<IMapper>(config.CreateMapper());
            config.AssertConfigurationIsValid();
        }

        protected void ConfigureContainer()
        {
            _container.RegisterType<IUnitOfWork, PalcoNetContext>();
            _container.RegisterType<ILoggingConfigurer, NLogLoggingConfigurer>();
            _container.RegisterType<ILoggerFactory, NLogLoggerFactory>();
            _container.RegisterType<IUsuarioBusiness, UsuarioBusiness>();
            _container.RegisterType<frmMain>();
            _container.RegisterType<frmLogin>();
        }

        protected void ConfigureLogging()
        {
            var configurer = _container.Resolve<ILoggingConfigurer>();
            configurer.Configure();
        }

        protected void ConfigureForms()
        {
            var config = new FormConfiguration(type =>
            {
                if (type.Equals(typeof(frmMain)))
                    return _container.Resolve<frmMain>();
                else if (type.Equals(typeof(frmLogin)))
                    return _container.Resolve<frmLogin>();
                else
                    throw new Exception("Provider no configurado");
            });

            _container.RegisterInstance<IFormFactory>(config.CreateFormFactory());
        }
    }
}
