using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.Shoes;
using api.interfaces;
using api.mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controller
{  
    [Route("api/shoes")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
           private readonly ApplicationDBContext _context;
            private readonly IShoesInterface _shoesRepository;
            public ShoesController(ApplicationDBContext context, IShoesInterface shoesRepository)
            {
            _shoesRepository = shoesRepository;
            _context  = context;  
            }   

       [HttpGet]

     public async Task<IActionResult> GetAll(){
           if (!ModelState.IsValid)
               return BadRequest(ModelState);

      var shoesList = await _shoesRepository.GetAllAsync();
      var shoestoList = shoesList.Select(item => item.ToShoesDTO()).ToList();
        return Ok(shoestoList); 
     }
      

     [HttpGet("{id:int}")]
        public async Task<IActionResult>GetById([FromRoute] int id)
        {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            var shoes = await _shoesRepository.GetByIdAsync(id);
            if(shoes == null){
                return NotFound();
            }
            return Ok(shoes);
        }

        [HttpPost]
        public async Task<IActionResult>Create([FromForm] CreateShoesRequestDto shoesDto, IFormFile formFile){
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var shoesModel = shoesDto.ToShoesFromCreateDTO();
            await _shoesRepository.CreatedAsync(shoesModel,formFile);
            return CreatedAtAction(nameof(GetById),new{id = shoesModel.Id}, shoesModel.ToShoesDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult>Update([FromRoute] int id, [FromForm] CreateShoesRequestDto shoesDto, IFormFile formFile){
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            var shoesModel = await _shoesRepository.UpdatedAsync(id,shoesDto,formFile);
            
            if(shoesModel == null){
                return NotFound();
            }

            return Ok(shoesModel);

        }


        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult>Delete([FromRoute] int id){
            var shoesModel = await _shoesRepository.DeletedAsync(id);
            if(shoesModel == null){
                return NotFound();
            }

            return NoContent();
        }
   
    
    }
}