using Business.Interfaces;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Implementations
{
    public abstract class ServiceCrud<TEntity, TEntityViewModel> : IServiceCrud<TEntity, TEntityViewModel> where TEntity : BaseEntity
                                                                                                            where TEntityViewModel : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        protected ServiceCrud(IRepository<TEntity> repository,
                                IMapper mapper)
            : base()
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IList<TEntityViewModel>> AllAsync(Expression<Func<TEntity, bool>> filters)
        {
            var list = _mapper.Map<IEnumerable<TEntity>, IList<TEntityViewModel>>(await _repository.AllAsync(filters));

            return list;
        }

        public virtual async Task<IList<TEntityViewModel>> AllAsync()
        {
            var list = _mapper.Map<IEnumerable<TEntity>, IList<TEntityViewModel>>(await _repository.AllAsync());

            return list;
        }

        public virtual async Task<TEntityViewModel> InsertAsync(TEntityViewModel model)
        {
            
            var entity = _mapper.Map<TEntity>(model);

            await _repository.InsertAsync(entity);

            return _mapper.Map<TEntityViewModel>(entity);
        }

        public virtual async Task<TEntityViewModel> UpdateAsync(TEntityViewModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

            await _repository.UpdateAsync(entity);

            return _mapper.Map<TEntityViewModel>(entity);
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

        public virtual async Task<TEntityViewModel> GetAsync(long id)
        {
            var entity = await _repository.FindAsync(id);
            return _mapper.Map<TEntity, TEntityViewModel>(entity);
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
