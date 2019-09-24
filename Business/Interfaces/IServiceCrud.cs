using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IServiceCrud<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> AllAsync();
        Task<IList<TEntity>> AllAsync(Expression<Func<TEntity, bool>> options);
        Task<TEntity> GetAsync(long id);
        Task<TEntity> InsertAsync(TEntity model);
        Task<TEntity> UpdateAsync(TEntity model);
        Task<bool> DeleteAsync(long id);
        Task<long> CountAsync();
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filters);
    }
}
