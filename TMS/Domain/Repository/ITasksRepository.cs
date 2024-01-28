using Domain.Entities;

namespace Domain.Repository
{
    public interface ITasksRepository : IBaseRepository
    {
        Task<IList<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(long id);
        Task<IList<TaskItem>> GetAllByUserIdAsync(long id);
    }
}
