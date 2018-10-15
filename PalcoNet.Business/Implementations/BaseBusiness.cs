using AutoMapper;
using PalcoNet.Dtos;
using PalcoNet.Dtos.Responses;
using PalcoNet.Entities.Implementations;
using PalcoNet.Infraestructure.Exceptions;
using PalcoNet.Infraestructure.Filters;
using PalcoNet.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Business.Implementations
{
    public abstract class BaseBusiness<TID, TEntity, TDto, TFilter>
        where TEntity : BaseEntity<TID>, new()
        where TDto : BaseDto<TID>, new()
        where TFilter : BaseFilter<TID>, new()
    {
        protected readonly IUnitOfWork uow = null;

        public BaseBusiness(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentException("La unidad de trabajo es obligatoria");
            this.uow = uow;
        }

        public Response<TDto> Insert(TDto TD)
        {
            var response = new Response<TDto>();
            try
            {
                TEntity TE = Mapper.Map<TDto, TEntity>(TD);
                uow.GetRepository<TEntity>().Insert(TE);
                response.Result.Messages.Add("Agregado satisfactorio");
                return response;
            }
            catch (Exception e)
            {
                response.Result.HasErrors = true;
                response.Result.Messages.Add("No se pudo borrar");
                response.Result.Exception = new TechnicalException("Error al ejecutar Delete", e);
                return response;
            }
        }

        public Response<TDto> Update(TDto TD)
        {
            var response = new Response<TDto>();
            try
            {
                TEntity TE = Mapper.Map<TDto, TEntity>(TD);
                uow.GetRepository<TEntity>().Update(TE);
                response.Result.Messages.Add("Actualizado satisfactorio");
                return response;
            }
            catch (Exception e)
            {
                response.Result.HasErrors = true;
                response.Result.Messages.Add("No se pudo borrar");
                response.Result.Exception = new TechnicalException("Error al ejecutar Delete", e);
                return response;
            }
        }

        public Response<TDto> Delete(TDto TD)
        {
            var response = new Response<TDto>();
            try
            {
                TEntity TE = Mapper.Map<TDto, TEntity>(TD);
                uow.GetRepository<TEntity>().Delete(TE);
                response.Result.Messages.Add("Borrado satisfactorio");
                return response;
            }
            catch (Exception e)
            {
                response.Result.HasErrors = true;
                response.Result.Messages.Add("No se pudo borrar");
                response.Result.Exception = new TechnicalException("Error al ejecutar Delete", e);
                return response;
            }
        }

        public Response<TDto> DeleteById(TDto TD)
        {
            var response = new Response<TDto>();
            try
            {
                TEntity TE = Mapper.Map<TDto, TEntity>(TD);
                uow.GetRepository<TEntity>().Delete<TID>(TD.Id);
                response.Result.Messages.Add("Borrado satisfactorio");
                return response;
            }
            catch (Exception e)
            {
                response.Result.HasErrors = true;
                response.Result.Messages.Add("No se pudo borrar");
                response.Result.Exception = new TechnicalException("Error al ejecutar DeleteById", e);
                return response;
            }
        }

        public Response<TDto> GetById(TID id)
        {
            var response = new Response<TDto>();
            try
            {
                TEntity TE = uow.GetRepository<TEntity>().GetById<TID>(id);
                TDto TD = Mapper.Map<TEntity, TDto>(TE);
                return response;
            }
            catch (Exception e)
            {
                response.Result.HasErrors = true;
                response.Result.Messages.Add("No se pudo obtener");
                response.Result.Exception = new TechnicalException("Error al ejecutar GetById", e);
                return response;
            }
        }

        public PagedListResponse<TDto> GetByFilter(TFilter filter)
        {
            int count = 0;
            var pagedListResponse = new PagedListResponse<TDto>();

            try
            {
                var query = OnFilter(uow.GetRepository<TEntity>().GetQuery(), filter);

                //query = filter.Id > 0 ? query.Where(q => q.Id == filter.Id) : query;
                query = filter.FechaBaja.HasValue ? query.Where(q => q.FechaBaja != filter.FechaBaja) : query;

                count = query.Count();
                if (filter.PageSize >= 0)
                {
                    query = query.Take(filter.PageSize);
                    query = query.Skip(filter.CurrentPage);
                }

                var listTE = query.ToList();
                var listDC = Mapper.Map<IList<TEntity>, IList<TDto>>(listTE);
                pagedListResponse.Count = count;
                pagedListResponse.Response.Data = listDC.ToList();
            }
            catch (Exception e)
            {
                pagedListResponse.Response.Result.HasErrors = false;
                pagedListResponse.Response.Result.Messages.Add("No se pudo obtener los datos de la BD");
                pagedListResponse.Response.Result.Exception = new TechnicalException("Error al ejecutar GetByFilter", e);
            }
            
            return pagedListResponse;
        }

        public IList<TDto> GetAll()
        {
            var listTE = uow.GetRepository<TEntity>().GetAll();
            var listDC = Mapper.Map<IList<TEntity>, IList<TDto>>(listTE);
            return listDC;
        }

        protected abstract IQueryable<TEntity> OnFilter(IQueryable<TEntity> query, TFilter filter);
    }
}
