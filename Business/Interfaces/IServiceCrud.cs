using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IServiceCrud<TEntity, TEntityViewModel> where TEntity : class
                                                                where TEntityViewModel : class
    {
        Task<IList<TEntityViewModel>> AllAsync();
        Task<IList<TEntityViewModel>> AllAsync(Expression<Func<TEntity, bool>> options);
        Task<TEntityViewModel> GetAsync(long id);
        Task<TEntityViewModel> InsertAsync(TEntityViewModel model);
        Task<TEntityViewModel> UpdateAsync(TEntityViewModel model);
        Task<bool> DeleteAsync(long id);
        Task<long> CountAsync();
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filters);
    }
}
