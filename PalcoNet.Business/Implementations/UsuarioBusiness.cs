using AutoMapper;
using PalcoNet.Dtos;
using PalcoNet.Dtos.Responses;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Filters;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Infraestructure.Extensions;
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

        public Response<UsuarioDto> GetByUserNamePassword(string userName, string password)
        {
            var responseView = new Response<UsuarioDto>();
            Response<List<UsuarioDto>> response = null;
            try
            {
                response = GetByFilter(new UsuarioFilter() { UserName = userName, Password = password });
                if (!response.Result.HasErrors)
                {
                    responseView.Data = response.Data.Single();
                }
            }
            catch (Exception e)
            {
                _logger.Error(e, "");
                responseView.Result.Messages.Add(string.Format("Ocurrio un error al loguearse: {0}", response.Result.Messages.First()));
            }

            return responseView;
        }

        protected override bool OnValidate(Usuario usuario)
        {
            return true;
        }

        protected override IQueryable<Usuario> OnFilter(IQueryable<Usuario> query, UsuarioFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.UserName))
                query = query.Where(q => q.UserName.Equals(filter.UserName));

            if (!string.IsNullOrEmpty(filter.Password))
                query = query.Where(q => q.Password.Equals(filter.Password));


            return query;
        }
    }
}
