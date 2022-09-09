using Financio.Infrastructure.Models;

namespace Financio.Application.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
        Task UpdateAsync(User user);
    }
}
