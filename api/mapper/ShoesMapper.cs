using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.Category;
using api.dtos.Shoes;
using api.models;

namespace api.mapper
{
    public static class ShoesMapper
    {
        public static ShoesDto ToShoesDTO(this Shoes shoesModel){
            return new ShoesDto
            {
                Id = shoesModel.Id,
                ShoesName = shoesModel.ShoesName,
                Price = shoesModel.Price,
                Size = shoesModel.Size,
                Stock = shoesModel.Stock,
                CreatedOn = shoesModel.CreatedOn,
                ImageUrl = shoesModel.ImageUrl,
                CategoryId = shoesModel.CategoryId,    Category = shoesModel.Category != null ? new CategoryDto
        {
            id = shoesModel.Category.id,
            CategoryName = shoesModel.Category.CategoryName,
            CreatedOn = shoesModel.Category.CreatedOn
        } : null
                 
        };
        }

        public static Shoes ToShoesFromCreateDTO(this CreateShoesRequestDto shoesDto){
            return new Shoes
            {
                ShoesName = shoesDto.ShoesName,
                Price = shoesDto.Price,
                Size = shoesDto.Size,
                Stock = shoesDto.Stock,
                CategoryId = shoesDto.CategoryId
            };
        }
    }
}