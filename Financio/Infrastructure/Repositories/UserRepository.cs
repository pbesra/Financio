using Financio.Application.IRepositories;
using Financio.Infrastructure.Models;

namespace Financio.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        List<User> _users;
        public UserRepository()
        {
            _users = new List<User>() { 
                new User{Id=1, UserName="akram.alam", Email="akaram.alam@gmail.com"},
                new User{Id=2, UserName="jon.doe", Email="jon.doe@gmail.com"},
                new User{Id=3, UserName="mark.wong", Email="mark.wong@gmail.com"},
                new User{Id=4, UserName="smith", Email="smith@gmail.com"},
                new User{Id=5, UserName="oliver", Email="oliver@gmail.com"},

            };
        }
        public async Task CreateAsync(User user)
        {
            _users.Add(user);
        }

        public async Task<List<User>> GetAll()
        {
            return _users;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return _users.Find(x => x.Email == email);
            
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return _users.Find(x => x.Id == id);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return _users.Find(x => x.UserName == userName);
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
