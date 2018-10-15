using PalcoNet.Repositories.Implementations;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace PalcoNet.App_Start
{
    public class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();
            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            return container;
        }
    }
}
