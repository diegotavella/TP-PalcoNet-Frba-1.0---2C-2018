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
using PalcoNet.Infraestructure.Security;
using PalcoNet.Business.Interfaces;

namespace PalcoNet.Business.Implementations
{
    public class UsuarioBusiness : BaseBusiness<Int64, Usuario, UsuarioDto, UsuarioFilter>, IUsuarioBusiness
    {
        public UsuarioBusiness(IUnitOfWork uow, IMapper mapper, ILoggerFactory loggerFactory) : base(uow, mapper, loggerFactory) 
        {

        }

        public Response<UsuarioDto> GetByUserNamePassword(string userName, string password)
        {
            var responseView = new Response<UsuarioDto>();
            try
            {
                var passwordT = SecurityHelper.EncodePassword(password, Algorithm.Sha256);
                var response = GetByFilter(new UsuarioFilter() { UserName = userName, Password = passwordT });
                if (!response.Result.HasErrors && response.Data.Count > 0)
                    responseView.Data = response.Data.Single();
                else if (!response.Result.HasErrors && response.Data.Count == 0)
                {
                    responseView.Result.HasErrors = true;
                    responseView.Result.Messages.Add("Usuario y/o password incorrecta");

                    // TODO: agregar intento de error en la bd
                    // si supero el limite bloquear usuario e informar
                }
                else
                    responseView.Result.Messages.Add(string.Format("Error: {0}", response.Result.Messages.FirstOrDefault()));
            }
            catch (Exception e)
            {
                _logger.Error(e, string.Format("Ocurrio un error al loguearse: usuario:{0}", userName));
                responseView.Result.Messages.Add("Ocurrio un error al loguearse");
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
