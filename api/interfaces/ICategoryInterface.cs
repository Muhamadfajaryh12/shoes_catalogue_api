using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.Category;
using api.models;

namespace api.interfaces
{
    public interface ICategoryInterface
    {
            Task<List<Category>> GetAllAsync();
            Task<Category?> GetByIdAsync(int id);
            Task<Category> CreatedAsync( Category categoryModel);
            Task<Category?> UpdatedAsync (int id, CreateCategoryRequestDto categoryDto);
            Task<Category?> DeletedAsync (int id);

    }
}