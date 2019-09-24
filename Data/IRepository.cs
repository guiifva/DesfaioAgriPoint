using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        IQueryable<TEntity> All(Expression<Func<TEntity, bool>> filters);
        TEntity Find(long key);
        void Insert(params TEntity[] obj);
        void Update(params TEntity[] obj);
        void Delete(params TEntity[] obj);
        long Count();
        bool Any(Expression<Func<TEntity, bool>> filters);

        Task<IList<TEntity>> AllAsync();
        Task<IList<TEntity>> AllAsync(Expression<Func<TEntity, bool>> filters);
        Task<TEntity> FindAsync(long key);
        Task InsertAsync(params TEntity[] obj);
        Task UpdateAsync(params TEntity[] obj);
        Task DeleteAsync(params TEntity[] obj);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> filters);
        Task<long> CountAsync();

    }
}
