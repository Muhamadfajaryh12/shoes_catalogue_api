using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos;
using api.dtos.Category;
using api.models;

namespace api.interfaces
{
    public interface ICategoryInterface
    {
            Task<ResponseDTO<Category>> GetAllAsync(); 
            Task<ResponseDTO<Category?>> GetByIdAsync(int id);
            Task<ResponseDTO<Category>> CreatedAsync( Category categoryModel);
            Task<Category?> UpdatedAsync (int id, CreateCategoryRequestDto categoryDto);
            Task<Category?> DeletedAsync (int id);

    }
}