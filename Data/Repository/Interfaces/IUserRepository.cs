using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> All();
        IQueryable<User> All(Expression<Func<User, bool>> filters);
        User Find(string key);
        void Insert(params User[] obj);
        void Update(params User[] obj);
        void Delete(params User[] obj);
        long Count();
        bool Any(Expression<Func<User, bool>> filters);

        Task<IList<User>> AllAsync();
        Task<IList<User>> AllAsync(Expression<Func<User, bool>> filters);
        Task<User> FindAsync(string key);
        Task<User> FindAsNoTrackingAsync(string key);
        Task<User> FindByEmailAsync(string email);
        Task InsertAsync(params User[] obj);
        Task UpdateAsync(params User[] obj);
        Task DeleteAsync(params User[] obj);
        Task<long> CountAsync(Expression<Func<User, bool>> filters);
        Task<long> CountAsync();
    }
}
