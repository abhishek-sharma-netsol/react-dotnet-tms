using Domain.Entities;
using Domain.Repository;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    internal sealed class UserRepository : BaseRepository, IUserRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public UserRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> FindByUserNameAsync(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == user.Email && u.UserName == user.UserName && u.Password == password);
        }
    }
}
