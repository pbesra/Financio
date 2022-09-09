using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Entities.EntitiesValidator;

namespace Financio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
        [Route("")]
        [Route("[action]")]
        public async Task<UserEntity> Index()
        {
            return new UserEntity
            {
                Id = 1,
                UserName = "prakash.besra"
            };
        }

        [HttpPost]
        [Route("Create")]
        public async Task<UserEntity> CreateUser([FromBody] UserEntity userEntity)
        {
            var validator = new UserEntityValidator();
            var valid = validator.Validate(userEntity);
            if (valid.IsValid)
            {
                Console.WriteLine(valid);
                return new UserEntity();
            }
            return userEntity;
        }
    }
}