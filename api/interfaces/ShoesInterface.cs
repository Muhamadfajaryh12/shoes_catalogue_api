using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.Shoes;
using api.models;

namespace api.interfaces
{
    public interface ShoesInterface
    {
        Task<List<Shoes>> GetAllAsync();
        Task<Shoes?> GetByIdAsync(int id);
        Task<Shoes> CreatedAsync(Shoes shoesModel);
        Task<Shoes?> UpdatedAsync(int id, CreateShoesRequestDto shoesDto);
        Task<Shoes?> DeletedAsync(int id);

    }
}