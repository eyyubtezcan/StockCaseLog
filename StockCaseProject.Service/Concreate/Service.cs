using Microsoft.EntityFrameworkCore;
using StockCaseProject.Repository.Abstract;
using StockCaseProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockCaseProject.Service.Concreate
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return entity; 
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void RemoveAsync(T entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
        }

        public async Task<bool> SingleOrDefaultAsync(Expression<Func<T, bool>> entities)
        {
            return await _repository.SingleOrDefaultAsync(entities);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public  IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return  _repository.Where(predicate);
        }
    }
}
