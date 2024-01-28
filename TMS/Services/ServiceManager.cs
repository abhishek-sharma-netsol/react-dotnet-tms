using Domain.Custom;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceAbstraction;
using ServiceAbstraction.Abstractions;
using Services.Services;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IAuthService> _lazyAuthService;
        private readonly Lazy<ITasksService> _lazyTasksService;

        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _lazyUserService = new Lazy<IUserService>(() => new UserService(repositoryManager));
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(repositoryManager, configuration));
            _lazyTasksService = new Lazy<ITasksService>(() => new TasksService(repositoryManager));
        }

        public IUserService UserService => _lazyUserService.Value;
        public IAuthService AuthService => _lazyAuthService.Value;
        public ITasksService TasksService => _lazyTasksService.Value;
    }
}