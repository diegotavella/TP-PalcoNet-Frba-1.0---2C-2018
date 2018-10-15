using PalcoNet.Dtos;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Filters;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Business.Implementations
{
    public class UsuarioBusiness : BaseBusiness<int, Usuario, UsuarioDto, UsuarioFilter>
    {
        public UsuarioBusiness(IUnitOfWork uow) : base(uow) { }

        protected override IQueryable<Usuario> OnFilter(IQueryable<Usuario> query, UsuarioFilter filter)
        {
            return query;
        }
    }
}
