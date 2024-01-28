using Domain.Repository;
using Domain.Response;
using ServiceAbstraction.Abstractions;

namespace Services.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            var entities = await _repositoryManager.UserRepository.GetAllAsync();
            return entities
                .Select(x => new UserResponse
                {
                    Id = x.Id,
                    Username = x.UserName,
                    Email = x.Email,
                })
                .ToList();
        }
    }
}
