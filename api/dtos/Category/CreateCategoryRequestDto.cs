using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.Category
{
    public class CreateCategoryRequestDto
    {
        [Required]
        [MinLength(5,ErrorMessage ="Name must be 5 Character")]
        [MaxLength(255,ErrorMessage = "Name cannot be over 255 Character")]
        public string CategoryName {get;set;} = string.Empty;
        public DateTime CreatedOn{get;set;} = DateTime.Now;
    }
}