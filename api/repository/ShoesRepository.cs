using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.Shoes;
using api.interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.repository
{
    public class ShoesRepository : IShoesInterface
    {
        private readonly ApplicationDBContext _context;

        public ShoesRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<List<Shoes>> GetAllAsync(){
           return await _context.Shoes
        .Include(s => s.Category) 
        .ToListAsync();
        }

        public async Task<Shoes?>GetByIdAsync(int id){
            var shoesModel = await _context.Shoes.FindAsync(id);
            if(shoesModel == null){
                return null;
            }
            return shoesModel;
        }

        public async Task<Shoes> CreatedAsync(Shoes shoesModel, IFormFile imageFile){
            if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName =  Guid.NewGuid().ToString()+"_"+Path.GetFileName(imageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images",fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    shoesModel.ImageUrl = $"/images/{fileName}";
                }

            await _context.Shoes.AddAsync(shoesModel);
            await _context.SaveChangesAsync();
            return shoesModel;
        }

        public async Task<Shoes?>UpdatedAsync(int id, CreateShoesRequestDto shoesDto, IFormFile imageFile){
            var shoesModel = await _context.Shoes.FirstOrDefaultAsync(x=> x.Id == id);
            if(shoesModel == null){
                return null;
            }

                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName =  Guid.NewGuid().ToString()+"_"+Path.GetFileName(imageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    shoesModel.ImageUrl = $"/images/{fileName}";
                }

                shoesModel.ShoesName = shoesDto.ShoesName;
                shoesModel.Price = shoesDto.Price;
                shoesModel.Size = shoesDto.Size;
                shoesModel.Stock = shoesDto.Stock;
                shoesModel.CategoryId = shoesDto.CategoryId;

            await _context.SaveChangesAsync();
            return shoesModel;

        }

        public async Task<Shoes?>DeletedAsync(int id){
            var shoesModel = await _context.Shoes.FirstOrDefaultAsync(x=> x.Id ==id);

            if(shoesModel == null){
                return null;
            }

            if(!string.IsNullOrEmpty(shoesModel.ImageUrl)){
                 var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", shoesModel.ImageUrl.TrimStart('/'));
                 if (System.IO.File.Exists(imagePath))
                    {
                        try
                        {
                            System.IO.File.Delete(imagePath); 
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error deleting image file.", ex);
                        }
                    }
            }

            _context.Shoes.Remove(shoesModel);
            await _context.SaveChangesAsync();
            return shoesModel;

        }
    }
}