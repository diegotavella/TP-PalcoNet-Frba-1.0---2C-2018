using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Forms
{
    public class PalcoNetFormFactory : IFormFactory
    {
        private Func<Type, IForm> _provider;

        public PalcoNetFormFactory(Func<Type, IForm> provider)
        {
            _provider = provider;
        }

        public void SetProvider(Func<Type, IForm> provider)
        {
            _provider = provider;
        }

        public IForm GetForm(Type formType)
        {
            if (_provider == null) throw new InvalidOperationException("Debe setear el provider antes de obtener el formulario");
            return _provider(formType);
        }

        public IForm GetForm<T>() where T : class
        {
            var formType = typeof(T);
            return GetForm(formType);
        }
    }
}
