using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Configurations;
using PalcoNet.Infraestructure.Exceptions;
using PalcoNet.Repositories.Implementations;
using PalcoNet.Repositories.Interfaces;
using PalcoNet.Repositories.ModelConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories
{
    /// <summary>
    /// DbContext es una unidad de trabajo
    /// </summary>
    public class PalcoNetContext : DbContext, IUnitOfWork
    {
        public PalcoNetContext() : base("PalcoNetContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(EnvironmentConfiguration.GetDefaultSchema());
            modelBuilder.Configurations.Add<Usuario>(new UsuarioConfiguration());
        }

        protected DbContextTransaction Transaction { get; set; }
        protected bool disposed = false;

        #region Implementations
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(this);
        }

        public IQueryable<T> SetEntity<T>() where T : class, new()
        {
            return base.Set<T>();
        }

        /// <summary>
        /// Graba los cambios
        /// </summary>
        public int Save()
        {
            try
            {
                var cant = base.SaveChanges();
                return cant;
            }
            catch (Exception ex)
            {
                throw new TechnicalException("Ocurrio un error al grabar los datos", ex);
            }
        }

        /// <summary>
        /// Abre una transaccion
        /// </summary>
        public void BeginTransaction()
        {
            BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// Abre una transaccion
        /// </summary>
        /// <param name="isolationLevel"></param>
        public void BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            try
            {
                this.Transaction = base.Database.BeginTransaction(isolationLevel);
            }
            catch (Exception ex)
            {
                throw new TechnicalException("Ocurrio un error al iniciar la transacción en la Base de datos", ex);
            }
        }

        /// <summary>
        /// Comitea todos los cambios realizados en la transaccion
        /// </summary>
        public void Commit()
        {
            try
            {
                base.SaveChanges();
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
            catch (Exception ex)
            {
                throw new TechnicalException("Ocurrio un error al grabar y commitear en la Base de datos", ex);
            }
        }

        /// <summary>
        /// Deshace todos los cambios generados en la transaccion
        /// </summary>
        public void Rollback()
        {
            try
            {
                // si no existe transacción no hace nada
                if (Transaction == null)
                    return;

                Transaction.Dispose();
                Transaction = null;
            }
            catch (Exception ex)
            {
                throw new TechnicalException("Ocurrio un error al realizar rollback en la Base de datos", ex);
            }
        }

        #endregion
    }
}
