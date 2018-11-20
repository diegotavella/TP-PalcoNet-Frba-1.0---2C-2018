using PalcoNet.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories.ModelConfigurations
{
    public class FuncionalidadConfiguration : EntityTypeConfiguration<Funcionalidad>
    {
        public FuncionalidadConfiguration()
        {
            ToTable("Funcionalidad");
            HasKey(x => x.Id);
            Property(q => q.Nombre).HasColumnName("UserName").IsRequired();
            Property(q => q.FechaBaja).HasColumnName("FechaBaja");
        }
    }
}
