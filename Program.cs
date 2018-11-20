using PalcoNet.App_Start;
using PalcoNet.Business.Implementations;
using PalcoNet.Dtos;
using PalcoNet.Forms;
using PalcoNet.Repositories;
using PalcoNet.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PalcoNet
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer container = new UnityContainer();
            BootStrapper.Configuration(container);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IFormFactory formFactory = container.Resolve<IFormFactory>();
            var frmMain = formFactory.GetForm<frmMain>();
            Application.Run((Form)frmMain);
        }
    }
}
