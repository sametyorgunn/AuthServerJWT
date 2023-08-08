using SharedLibrary.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Service
{
    public interface IGenericService<TEntity,TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> TGetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> TGetAllAsync();
        Task<Response<TDto>>TAddAsync(TEntity entity);
        Task<Response<NoDataDto>> Remove(TEntity entity);
        Task<Response<NoDataDto>> Update(TEntity entity);
        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
