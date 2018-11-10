using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Logging
{
    public class NLogLoggingConfigurer : ILoggingConfigurer
    {
        public void Configure()
        {
            var config = new XmlLoggingConfiguration(System.AppDomain.CurrentDomain.BaseDirectory + "App.config");
            // TODO: no usar codigo, usar solo el de web.config
            config.AddTarget("Trace", new TraceTarget()
            {
                Layout = CreateJsonLayout()
            });
        }

        private JsonLayout CreateJsonLayout()
        {
            return new JsonLayout
            {
                Attributes =
                {
                    new JsonAttribute("level", "${level:upperCase=true}"),
                    new JsonAttribute("message", "${message}"),
                    new JsonAttribute("logger", "${logger:shortname=true}"),
                    new JsonAttribute("xsi:type", "File"),
                    new JsonAttribute("fileName", @"logs\FarmacityTrace.log"),
                    new JsonAttribute("archiveFileName", @"logs\Farmacity_Trace_${shortdate}.{##}.log"),
                    new JsonAttribute("archiveEvery", "Day"),
                    new JsonAttribute("maxArchiveFiles", "30"),
                    new JsonAttribute("message", "${exception:format=Message}"),
                    new JsonAttribute("innerException", new JsonLayout
                    {
                        Attributes =
                        {
                            new JsonAttribute("type", "${exception:format=:innerFormat=Type:MaxInnerExceptionLevel=1:InnerExceptionSeparator=}"),
                            new JsonAttribute("message", "${exception:format=:innerFormat=Message:MaxInnerExceptionLevel=1:InnerExceptionSeparator=}"),
                        }
                    })
                }
            };
        }
    }
}
