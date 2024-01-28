using Domain.Entities;

namespace Domain.Repository
{
    public interface IUserRepository : IBaseRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> FindByUserNameAsync(string userName);
        Task<User?> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
