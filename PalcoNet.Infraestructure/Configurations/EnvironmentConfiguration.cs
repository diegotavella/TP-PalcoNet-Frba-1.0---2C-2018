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
        /// Lee la configuracion del webconfig para el valor DefaultSchema
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultSchema()
        {
            return ConfigHelper.GetParameterWebConfig("DefaultSchema");
        }
    }
}
