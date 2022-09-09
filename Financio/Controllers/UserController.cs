using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Entities.EntitiesValidator;
using System.ComponentModel.DataAnnotations;
using Financio.Domain.Validator;

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
        [Route("")]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] UserEntity userEntity)
        {
            var validator = new UserEntityValidator();
            var valid = validator.Validate(userEntity);
            if (!valid.IsValid)
            {
                var responseErrors = new ResponseErrors<UserEntity>(valid.Errors);
                return BadRequest(responseErrors.GetErrors());
            }
            return Ok(userEntity);
        }

        [HttpPut]
        [Route("")]
        [Route("[action]")]
        public async Task<UserEntity> UpdateUser([FromBody] UserEntity user)
        {
            return new UserEntity { Id = 1, UserName = "prakash.besra" };
        }
    }
}