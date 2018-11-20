using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Forms
{
    public class FormConfiguration : IFormConfiguration
    {
        private readonly Func<Type, IForm> _provider = null;
        public FormConfiguration(Func<Type, IForm> provider)
        {
            _provider = provider;
        }

        public IFormFactory CreateFormFactory()
        {
            return new PalcoNetFormsFactory(_provider);
        }
    }
}
