using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Forms
{
    public interface IFormFactory
    {
        void SetProvider(Func<Type, IForm> provider);
        IForm GetForm(Type formType);
        IForm GetForm<T>() where T : class;
    }
}
