using AutoMapper;
using PalcoNet.Dtos;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Filters;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Business.Implementations
{
    public class UsuarioBusiness : BaseBusiness<Int64, Usuario, UsuarioDto, UsuarioFilter>
    {
        public UsuarioBusiness(IUnitOfWork uow, IMapper mapper, ILoggerFactory loggerFactory) : base(uow, mapper, loggerFactory) { }

        protected override bool OnValidate(Usuario usuario)
        {
            return true;
        }

        protected override IQueryable<Usuario> OnFilter(IQueryable<Usuario> query, UsuarioFilter filter)
        {
            return query;
        }
    }
}
