using DevFreela.Core.Entities;
using DevFreela.CORE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;

        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passowordHash)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email &&
                                                             u.Password == passowordHash);
        }
    }
}
