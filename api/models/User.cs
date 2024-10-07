using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class User
    {
        public int Id {get;set;}
        public string Username {get;set;} = String.Empty;
        public string Password {get;set;} = String.Empty;
    }
}