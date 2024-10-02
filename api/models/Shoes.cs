using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models{
    public class Shoes{
        public int id{
            get;set;
        }

        public string ShoesName {get;set;} = string.Empty;
        public long Price {get;set;}
        public int Size {get;set;}

        public DateTime CreatedOn{get;set;} = DateTime.Now;
        public int? CategoryId{get;set;}
        public Category? Category{get;set;}

    }
}