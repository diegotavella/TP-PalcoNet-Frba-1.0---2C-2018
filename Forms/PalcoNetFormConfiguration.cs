using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Forms
{
    public class PalcoNetFormConfiguration : IFormConfiguration
    {
        private readonly Func<Type, IForm> _provider = null;
        public PalcoNetFormConfiguration(Func<Type, IForm> provider)
        {
            _provider = provider;
        }

        public IFormFactory CreateFormFactory()
        {
            if (_provider == null) throw new InvalidOperationException("Debe setear el provider antes de crear el factory");
            return new PalcoNetFormFactory(_provider);
        }
    }
}
