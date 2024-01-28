using Domain.Repository;
using Persistance.Repositories;

namespace Persistance
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ITasksRepository> _tasksRepository;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
            _tasksRepository = new Lazy<ITasksRepository>(() => new TasksRepository(dbContext));
        }

        public IUserRepository UserRepository => _userRepository.Value;
        public ITasksRepository TasksRepository => _tasksRepository.Value;
    }
}