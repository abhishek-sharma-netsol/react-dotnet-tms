using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    internal class TasksRepository : BaseRepository, ITasksRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public TasksRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TaskItem>> GetAllAsync()
        {
            return await _dbContext.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(long id)
        {
            return await _dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IList<TaskItem>> GetAllByUserIdAsync(long id)
        {
            return await _dbContext.TaskItems.Where(t => t.UserId == id).ToListAsync();
        }
    }
}
