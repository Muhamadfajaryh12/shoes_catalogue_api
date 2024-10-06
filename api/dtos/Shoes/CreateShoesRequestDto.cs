using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.Shoes
{
    public class CreateShoesRequestDto
    {
        [Required]
        [MinLength(5,ErrorMessage = "Name must be 5 Character")]
        [MaxLength(255,ErrorMessage = "Name cannot be over 255 Character")]
        public string ShoesName {get;set;} = string.Empty;
        [Required]
        public long Price {get;set;} = 0;
        [Required]
        public int Size {get;set;} = 0;
        [Required]
        public int Stock {get;set;} = 0;
        [Required]
        public int? CategoryId{get;set;}


    }
}