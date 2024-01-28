using ServiceAbstraction.Abstractions;

namespace ServiceAbstraction
{
    public interface IServiceManager
    {
        public IUserService UserService { get; }

        public IAuthService AuthService { get; }

        public ITasksService TasksService { get; }
    }
}
