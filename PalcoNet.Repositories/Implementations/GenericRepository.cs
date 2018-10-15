using PalcoNet.Entities.Implementations;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories.Implementations
{
    public class GenericRepository<TE> : IRepository<TE> 
        where TE : class, new()
    {
        private readonly IDbSet<TE> _dbSet;
        public GenericRepository(IUnitOfWork context)
        {
            _dbSet = (IDbSet<TE>)context.SetEntity<TE>();
        }

        /// <summary>
        /// Arma una query a traves del filtro como expression lambda
        /// las propiedades son para agregar las relaciones
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public virtual IQueryable<TE> GetByExpression(Expression<Func<TE, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TE> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return query;
        }

        public IQueryable<TE> GetQuery()
        {
            return _dbSet.AsQueryable<TE>();
        }

        /// <summary>
        /// Obtiene una entidad a traves de su id pk
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TE GetById<TID>(TID id)
        {
            TE entity = _dbSet.Find(id);
            return entity;
        }

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        /// <returns></returns>
        public virtual IList<TE> GetAll()
        {
            return (IList<TE>)_dbSet.ToList<TE>();
        }

        /// <summary>
        /// Obtiene el numero de registros
        /// </summary>
        /// <returns></returns>
        public virtual int GetCount()
        {
            return _dbSet.Count();
        }

        /// <summary>
        /// Inserta una entidad
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TE entity)
        {
            TE e = _dbSet.Attach(entity);
            _dbSet.Add(entity);
            //_dbContext.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Actualiza la entidad
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TE entityToUpdate)
        {
            TE e = _dbSet.Attach(entityToUpdate);
            //_dbContext.Entry(e).State = EntityState.Modified;
        }

        /// <summary>
        /// Borra la entidad
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TE entityToDelete)
        {
            //if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
              //  _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Borra la entidad a traves del id pk
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete<TID>(TID id)
        {
            TE entityToDelete = GetById<TID>(id);
            Delete(entityToDelete);
        }
    }
}
