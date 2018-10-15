using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories.Interfaces
{
    public interface IRepository<TE> where TE : class, new()
    {
        IQueryable<TE> GetByExpression(Expression<Func<TE, bool>> filter = null, string includeProperties = "");
        IQueryable<TE> GetQuery();
        TE GetById<TID>(TID id);
        IList<TE> GetAll();
        int GetCount();
        void Insert(TE entity);
        void Update(TE entityToUpdate);
        void Delete(TE entityToDelete);
        void Delete<TID>(TID id);
    }
}
