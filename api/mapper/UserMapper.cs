using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.User;
using api.models;

namespace api.mapper
{
    public  static class UserMapper
    {

        public static User ToUserFromCreateDTO (this UserDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };
        }
    }
}