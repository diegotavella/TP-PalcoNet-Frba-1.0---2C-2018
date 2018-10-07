using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Configurations;
using PalcoNet.Repositories.ModelConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories
{
    public class PalcoNetContext : DbContext
    {
        public PalcoNetContext()
            : base("PalcoNetContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(EnvironmentConfiguration.GetDefaultSchema());
            modelBuilder.Configurations.Add<Usuario>(new UsuarioConfiguration());
        }


    }
}
