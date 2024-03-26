using DevFreela.Core.Entities;

namespace DevFreela.CORE.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
