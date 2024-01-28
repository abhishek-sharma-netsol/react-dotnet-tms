using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    internal abstract class BaseRepository : IBaseRepository
    {
        private readonly RepositoryDbContext _dbContext;

        protected BaseRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync<T>(T entity) where T : class => await _dbContext.AddAsync(entity);

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class => await _dbContext.AddRangeAsync(entities);

        public void Update<T>(T entity) where T : class => _dbContext.Entry(entity).State = EntityState.Modified;

        public async Task UpdateAsync<T>(T entity) where T : class => await Task.Run(() => _dbContext.Update(entity));

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class => _dbContext.UpdateRange(entities);

        public async Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class =>
            await Task.Run(() => _dbContext.UpdateRange(entities));

        public void Delete<T>(T entity) where T : class => _dbContext.Remove(entity);

        public void DeleteRange<T>(IEnumerable<T> entities) where T : class => _dbContext.RemoveRange(entities);

        public async Task DetachAsync<T>(T entity) where T : class => await Task.Run(() =>
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
        });

        public async Task DetachRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
            }

            await Task.CompletedTask; // Just to satisfy the async signature
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();

        public async Task<bool> SaveChangesAsync() => await _dbContext.SaveChangesAsync() > 0;
    }
}
