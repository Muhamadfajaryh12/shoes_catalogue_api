using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;

namespace api.dtos.Category
{
    public class ShoesDto
    {
        public int Id{get;set;}
   
        public string ShoesName {get;set;} = string.Empty;
        public long Price {get;set;} = 0;
        public int Size {get;set;} = 0;
        public int Stock {get;set;} = 0;

        public DateTime CreatedOn{get;set;} = DateTime.Now;

        public string? ImageUrl{get;set;} = string.Empty;
        public int? CategoryId{get;set;}    
         public CategoryDto? Category { get; set; } 

    }
}