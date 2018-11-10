using PalcoNet.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Configurations
{
    public static class EnvironmentConfiguration
    {
        /// <summary>
        /// Lee la configuracion AppSettings del App.config el valor de la entrada DefaultSchema de la BD
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultSchema()
        {
            return ConfigHelper.GetParameterWebConfig("DefaultSchema");
        }
    }
}
