using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Forms
{
    public interface IFormConfiguration
    {
        IFormFactory CreateFormFactory();
    }
}
