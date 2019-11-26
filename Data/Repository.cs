using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> All(Expression<Func<TEntity, bool>> filters)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                .Where(filters)
                .AsNoTracking();
            return query;
        }

        public virtual IQueryable<TEntity> All() => _context.Set<TEntity>().AsNoTracking();

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filters) =>
            await _context.Set<TEntity>().AnyAsync(filters);

        public void Update(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Delete(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public TEntity Find(long key)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                .Where(x => x.Id == key);

            return query.FirstOrDefault();
        }

        public void Insert(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
        }

        public long Count()
        {
            return _context.Set<TEntity>().LongCount();
        }

        public long Count(Expression<Func<TEntity, bool>> filters)
        {
            return _context.Set<TEntity>().Where(filters).LongCount();
        }

        public bool Any(Expression<Func<TEntity, bool>> filters) =>
            _context.Set<TEntity>().Any(filters);


        public async Task UpdateAsync(params TEntity[] obj)
        {
            _context.Set<TEntity>().UpdateRange(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params TEntity[] obj)
        {
            _context.Set<TEntity>().RemoveRange(obj);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IList<TEntity>> AllAsync(Expression<Func<TEntity, bool>> filters)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                    .Where(filters)
                    .AsNoTracking();

            return await query.ToListAsync();
        }


        public virtual async Task<IList<TEntity>> AllAsync()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(long key)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>()
                .Where(x => x.Id == key);

            return await query.FirstOrDefaultAsync();
        }

        public async Task InsertAsync(params TEntity[] obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filters)
        {
            return await _context.Set<TEntity>().Where(filters).LongCountAsync();
        }

        public async Task<long> CountAsync()
        {
            return await _context.Set<TEntity>().LongCountAsync();
        }

    }
}

