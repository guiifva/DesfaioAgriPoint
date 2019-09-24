using Business.Interfaces;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public abstract class ServiceCrud<TEntity> : IServiceCrud<TEntity> where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _repository;

        protected ServiceCrud(IRepository<TEntity> repository)
            : base()
        {
            _repository = repository;
        }

        public virtual async Task<IList<TEntity>> AllAsync(Expression<Func<TEntity, bool>> filters)
        {
            var list = await _repository.AllAsync(filters);

            return list;
        }

        public virtual async Task<IList<TEntity>> AllAsync()
        {
            var list = await _repository.AllAsync();

            return list;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity model)
        {
            
            await _repository.InsertAsync(model);

            return model;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity model)
        {
            await _repository.UpdateAsync(model);

            return model;
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            await _repository.DeleteAsync(entity);

            return true;
        }

        public virtual async Task<TEntity> GetAsync(long id)
        {
            var entity = await _repository.FindAsync(id);

            return entity;
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filters)
        {
            return await _repository.CountAsync(filters);
        }

        public async Task<long> CountAsync()
        {
            return await _repository.CountAsync();
        }
    }
}
