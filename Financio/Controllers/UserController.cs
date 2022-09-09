using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Entities.EntitiesValidator;
using System.ComponentModel.DataAnnotations;
using Financio.Domain.Validator;
using Financio.Application.IServices;
using AutoMapper;
using System.Net.Mime;

namespace Financio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var userList = await _userService.GetAll();
            var userEntities=_mapper.Map<List<UserEntity>>(userList);
            return Ok(userEntities);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userEntity = _mapper.Map<UserEntity>(user);
            if (userEntity == null)
            {
                return NotFound();
            }
            return Ok(userEntity);
        }

        [HttpGet]
        [Route("Query")]
        public async Task<IActionResult> Index([FromQuery(Name = "userName")] string userName)
        {
            var user = await _userService.GetByUserNameAsync(userName);
            var userEntity = _mapper.Map<UserEntity>(user);
            if(userEntity == null)
            {
                return NotFound();
            }
            return Ok(userEntity);
        }



        [HttpPost]
        [Route("")]
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
        public async Task<UserEntity> UpdateUser([FromBody] UserEntity user)
        {
            return new UserEntity { Id = 1, UserName = "prakash.besra" };
        }
    }
}