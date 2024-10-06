using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos
{
    public class ResponseDTO<T>
    {
        public bool Success {get;set;}
        public string? Message {get;set;}
        public object? Data { get; set; }    
    }
}