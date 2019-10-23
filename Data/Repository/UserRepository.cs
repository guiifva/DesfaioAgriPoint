
using Data.Models;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual IQueryable<User> All(Expression<Func<User, bool>> filters)
        {
            IQueryable<User> query = _context.Set<User>()
                .Where(filters)
                .AsNoTracking();
            return query;
        }

        public virtual IQueryable<User> All()
        {
            IQueryable<User> query = _context.Set<User>()
                .AsNoTracking();
            return query;
        }

        public void Update(params User[] obj)
        {
            _context.Set<User>().UpdateRange(obj);
            _context.SaveChanges();
        }

        public void Delete(params User[] obj)
        {
            _context.Set<User>().RemoveRange(obj);
            _context.SaveChanges();
        }

        public User Find(string key)
        {
            IQueryable<User> query = _context.Set<User>()
                .Where(x => x.Id == key);

            return query.FirstOrDefault();
        }

        public void Insert(params User[] obj)
        {
            _context.Set<User>().AddRange(obj);
            _context.SaveChanges();
        }

        public long Count()
        {
            return _context.Set<User>().LongCount();
        }

        public long Count(Expression<Func<User, bool>> filters)
        {
            return _context.Set<User>().Where(filters).LongCount();
        }

        public bool Any(Expression<Func<User, bool>> filters) =>
            _context.Set<User>().Any(filters);


        public async Task UpdateAsync(params User[] obj)
        {
            _context.Set<User>().UpdateRange(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(params User[] obj)
        {
            _context.Set<User>().RemoveRange(obj);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IList<User>> AllAsync(Expression<Func<User, bool>> filters)
        {
            IQueryable<User> query = _context.Set<User>()
                    .Where(filters)
                    .AsNoTracking();

            return await query.ToListAsync();
        }


        public virtual async Task<IList<User>> AllAsync()
        {
            IQueryable<User> query = _context.Set<User>()
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<User> FindAsync(string key)
        {
            IQueryable<User> query = _context.Set<User>()
                .Where(x => x.Id == key);

            return await query.FirstOrDefaultAsync();
        }

        public async Task InsertAsync(params User[] obj)
        {
            _context.Set<User>().AddRange(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<long> CountAsync(Expression<Func<User, bool>> filters)
        {
            return await _context.Set<User>().Where(filters).LongCountAsync();
        }

        public async Task<long> CountAsync()
        {
            return await _context.Set<User>().LongCountAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> filters) =>
            await _context.Set<User>().AnyAsync(filters);
    }
}

