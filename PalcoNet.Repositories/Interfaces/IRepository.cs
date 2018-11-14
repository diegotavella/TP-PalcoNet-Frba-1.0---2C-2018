using PalcoNet.Dtos.Filters;
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
        IQueryable<TE> GetQuery(Pager pager);
        TE GetById<TID>(TID id);
        IList<TE> GetAll();
        IList<TE> GetAll(Pager pager);
        int GetCount();
        void Insert(TE entity);
        void Update(TE entityToUpdate);
        void Delete(TE entityToDelete);
        void Delete<TID>(TID id);
    }
}
