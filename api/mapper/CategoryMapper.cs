using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.Category;
using api.models;

namespace api.mapper
{
    public  static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel){
            return new CategoryDto
            {
                id = categoryModel.id,
                CategoryName = categoryModel.CategoryName,
                CreatedOn = categoryModel.CreatedOn
            };
        }

        public static Category ToCategoryFromCreateDTO(this CreateCategoryRequestDto categoryDto){
            return new Category
            {
                CategoryName = categoryDto.CategoryName,               
                CreatedOn = categoryDto.CreatedOn
            };
        }


    }
}