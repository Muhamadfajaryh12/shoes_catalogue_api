using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models{
    public class Category{
        public int id{
            get;set;
        }

        public string CategoryName {get;set;} = string.Empty;
        public DateTime CreatedOn{get;set;} = DateTime.Now;

    }
}