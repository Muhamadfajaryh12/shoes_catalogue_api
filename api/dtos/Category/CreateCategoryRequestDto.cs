using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dtos.Category
{
    public class CreateCategoryRequestDto
    {
        public string CategoryName {get;set;} = string.Empty;
        public DateTime CreatedOn{get;set;} = DateTime.Now;
    }
}