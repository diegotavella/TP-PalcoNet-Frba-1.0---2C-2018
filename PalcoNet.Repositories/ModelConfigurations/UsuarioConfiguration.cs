using PalcoNet.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositories.ModelConfigurations
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(q => q.UserName).HasColumnName("UserName").IsRequired();
            Property(q => q.Password).HasColumnName("Password").IsRequired();
            Property(q => q.Inhabilitado).HasColumnName("Inhabilitado");
            Property(q => q.CantIntentosFallidos).HasColumnName("CantIntentosFallidos");
            Property(q => q.MaxIntentosFallidos).HasColumnName("MaxIntentosFallidos");
            Property(q => q.PrimerIngreso).HasColumnName("PrimerIngreso");
            Property(q => q.FechaBaja).HasColumnName("FechaBaja");
        }
    }
}
