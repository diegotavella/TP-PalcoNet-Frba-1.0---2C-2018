using PalcoNet.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        IQueryable<T> SetEntity<T>() where T : class, new();
        int Save();
        void BeginTransaction();
        void BeginTransaction(System.Data.IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
    }
}
