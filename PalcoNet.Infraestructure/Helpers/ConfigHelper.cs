using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Helpers
{
    public static class ConfigHelper
    {
        public static string GetParameterWebConfig(string parameter)
        {
            string name = string.Empty;

            if (ConfigurationManager.AppSettings.HasKeys())
            {
                try
                {
                    name = ConfigurationManager.AppSettings[parameter];
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }

            return (string.IsNullOrEmpty(name) ? string.Empty : name);
        }
    }
}
