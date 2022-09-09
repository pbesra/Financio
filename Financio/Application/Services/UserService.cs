using Financio.Application.IRepositories;
using Financio.Application.IServices;
using Financio.Infrastructure.Models;

namespace Financio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task CreateAsync(User user)
        {
            this._userRepository.CreateAsync(user);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await this._userRepository.GetByEmailAsync(email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await this._userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await this._userRepository.GetByUserNameAsync(userName);
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
