using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.User;
using api.interfaces;
using api.mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserInterface _userRepository;

        public UserController(ApplicationDBContext context, IUserInterface userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult>Register([FromBody] UserDto userModel)
        {
            await _userRepository.Register(userModel.ToUserFromCreateDTO());
            return Ok(userModel);
        }

        [HttpPost("login")]

        public async Task<IActionResult>Login([FromBody] UserDto userModel){
            var  user = await _userRepository.Login(userModel.ToUserFromCreateDTO());
            if(user == null){
                return BadRequest(
                    new {Message = "Username or Password not match"}
                );
            }
            return Ok(user);
        }
    }
}