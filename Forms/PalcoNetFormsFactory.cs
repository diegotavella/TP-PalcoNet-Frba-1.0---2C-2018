using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Forms
{
    public class PalcoNetFormsFactory : IFormFactory
    {
        private Func<Type, IForm> _provider;

        public PalcoNetFormsFactory(Func<Type, IForm> provider)
        {
            _provider = provider;
        }

        public void SetProvider(Func<Type, IForm> provider)
        {
            _provider = provider;
        }

        public IForm GetForm(Type formType)
        {
            return _provider(formType);
        }

        public IForm GetForm<T>() where T : class
        {
            var formType = typeof(T);
            return _provider(formType);
        }
    }
}
