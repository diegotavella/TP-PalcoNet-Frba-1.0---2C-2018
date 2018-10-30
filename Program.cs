using PalcoNet.App_Start;
using PalcoNet.Business.Implementations;
using PalcoNet.Dtos;
using PalcoNet.Repositories;
using PalcoNet.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            BootStrapper.Configuration();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            

            Application.Run(new FrmMain());
        }
    }
}
