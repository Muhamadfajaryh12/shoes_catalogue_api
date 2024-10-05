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
    public class ShoesRepository : ShoesInterface
    {
        private readonly ApplicationDBContext _context;

        public ShoesRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<List<Shoes>> GetAllAsync(){
            return await _context.Shoes.ToListAsync();
        }

        public async Task<Shoes?>GetByIdAsync(int id){
            var shoesModel = await _context.Shoes.FindAsync(id);
            if(shoesModel == null){
                return null;
            }
            return shoesModel;
        }

        public async Task<Shoes>CreatedAsync(Shoes shoesModel){
            await _context.Shoes.AddAsync(shoesModel);
            await _context.SaveChangesAsync();
            return shoesModel;
        }

        public async Task<Shoes?>UpdatedAsync(int id, CreateShoesRequestDto shoesDto){
            var shoesModel = await _context.Shoes.FirstOrDefaultAsync(x=> x.Id == id);
            if(shoesModel == null){
                return null;
            }
                shoesModel.ShoesName = shoesDto.ShoesName;
                shoesModel.Price = shoesDto.Price;
                shoesModel.Size = shoesDto.Size;
                shoesModel.Stock = shoesDto.Stock;
                shoesModel.CreatedOn = shoesDto.CreatedOn;
                shoesModel.ImageUrl = shoesDto.ImageUrl;
                shoesModel.CategoryId = shoesDto.CategoryId;
                
            await _context.SaveChangesAsync();
            return shoesModel;

        }

        public async Task<Shoes?>DeletedAsync(int id){
            var shoesModel = await _context.Shoes.FirstOrDefaultAsync(x=> x.Id ==id);
            if(shoesModel == null){
                return null;
            }

            _context.Shoes.Remove(shoesModel);
            await _context.SaveChangesAsync();
            return shoesModel;

        }
    }
}