using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos;
using api.dtos.Category;
using api.interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class CategoryRepository : ICategoryInterface
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context){
            _context = context;
        }
        public async Task<ResponseDTO<Category>> GetAllAsync()
        {
                var categoryModel = await _context.Category.ToListAsync();

                var response = new ResponseDTO<Category>
                {
                    Success = true,
                    Message = "Categories retrieved successfully",
                    Data = categoryModel 
                };

                return response; 
        }
        

        public async Task<ResponseDTO<Category?>>GetByIdAsync(int id){
            var categoryModel = await _context.Category.FindAsync(id);

            if(categoryModel == null){
                return null;
            }
            var response = new ResponseDTO<Category>
            {
                Success = true,
                Message = "Categories retrieved successfully",
                Data = categoryModel 
            };

            return response;
        }

        public async Task<ResponseDTO<Category>> CreatedAsync(Category categoryModel){
            await _context.Category.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            var response = new ResponseDTO<Category>
            {
                Success = true,
                Message = "Category created successfully",
                Data = new List<Category> { categoryModel }
            };

            return response;
         
        }

        public async Task<Category?> UpdatedAsync(int id, CreateCategoryRequestDto categoryDto){
            var categoryModel = await _context.Category.FirstOrDefaultAsync(x=> x.id == id);
            if(categoryModel == null){
                return null;
            }
            categoryModel.CategoryName = categoryDto.CategoryName;
            await _context.SaveChangesAsync();
            return categoryModel;

        }
        public async Task<Category?> DeletedAsync(int id){
            var categoryModel = await _context.Category.FirstOrDefaultAsync(x=> x.id == id);

            if(categoryModel == null){
                return null;
            }

            _context.Category.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

   
    }

  
}