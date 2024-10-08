using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.interfaces;
using api.models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.repository
{
    public class UserRepository :IUserInterface
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<User> Login(User userModel)
        {
            var user = _context.User.FirstOrDefault(x=> x.Username == userModel.Username );
            if(user == null){
                return null;
            }

            var validationPassword = BCrypt.Net.BCrypt.Verify(userModel.Password, user.Password);
            if(!validationPassword){
                return null;
            }

            return userModel;
            
        }


        public  async Task<User> Register(User userModel)
        {

            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            await _context.User.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }
    }
}