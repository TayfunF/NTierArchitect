using Microsoft.EntityFrameworkCore;
using NTierArchitect.Core.Repositories;
using NTierArchitect.Core.Services;
using NTierArchitect.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitect.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> Repository;
        private readonly IUnitOfWork UnitOfWork;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await Repository.AddAsync(entity);
            await UnitOfWork.CommitAsync();

            return entity;

        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await Repository.AddRangeAsync(entities);
            await UnitOfWork.CommitAsync();

            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await Repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            Repository.Remove(entity);
            await UnitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            Repository.RemoveRange(entities);
            await UnitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Repository.Update(entity);
            await UnitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Repository.Where(expression);
        }
    }
}
