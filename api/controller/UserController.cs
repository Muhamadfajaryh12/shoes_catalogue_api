using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api.controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController: ControllerBase
    {
        public async Task<IActionResult>Register([FromBody])
        {

        }

        public async Task<IActionResult>Login([FromBody])
        {
            
        }
    }
}