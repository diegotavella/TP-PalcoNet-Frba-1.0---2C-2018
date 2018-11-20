using PalcoNet.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories.ModelConfigurations
{
    public class RolConfiguration : EntityTypeConfiguration<Rol>
    {
        public RolConfiguration()
        {
            ToTable("Rol");
            HasKey(x => x.Id);
            Property(q => q.Nombre).HasColumnName("UserName").IsRequired();
            Property(q => q.Descripcion).HasColumnName("Password").IsRequired();
            Property(q => q.FechaBaja).HasColumnName("FechaBaja");

            HasMany(q => q.Funcionalidades).WithMany();
        }
    }
}
