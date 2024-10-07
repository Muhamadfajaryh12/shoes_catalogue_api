using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using api.models;

namespace api.repository
{
    public class UserRepository :IUserInterface
    {
        public Task<User> Login(User userModel)
        {
            
            throw new NotImplementedException();
        }


        public Task<User> Register(User userModel)
        {
            throw new NotImplementedException();
        }
    }
}