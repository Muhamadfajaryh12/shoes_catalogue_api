using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.User
{
    public class UserDto
    {
        [Required]
        public string Username{get;set;} = string.Empty;
        [Required]
        public string Password{get;set;} = string.Empty;
    }
}