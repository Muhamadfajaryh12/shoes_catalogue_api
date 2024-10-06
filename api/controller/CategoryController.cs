using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.Category;
using api.interfaces;
using api.mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.controller
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
     private readonly ApplicationDBContext _context;
     private readonly ICategoryInterface _categoryRepository;
     public CategoryController(ApplicationDBContext context, ICategoryInterface categoryRepository)
     {
      _categoryRepository = categoryRepository;
      _context  = context;  
     }   

     [HttpGet]

     public async Task<IActionResult> GetAll() {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoryListResponse = await _categoryRepository.GetAllAsync();

        // Memastikan ResponseDTO berhasil
        if (!categoryListResponse.Success)
        {
            return BadRequest(categoryListResponse.Message);
        }

        // Mengembalikan data kategori
        return Ok(categoryListResponse); // Kembalikan data kategori dalam response
    }

     [HttpGet("{id:int}")]

     public async Task<IActionResult> GetById([FromRoute] int id){
       if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var category = await _categoryRepository.GetByIdAsync(id);
        if(category == null){
            return NotFound();
        }
        return Ok(category);
     }  

     [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto){      
          if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var categoryModel = categoryDto.ToCategoryFromCreateDTO();
        await _categoryRepository.CreatedAsync(categoryModel);
        return CreatedAtAction(nameof(GetById), new { id = categoryModel.id}, categoryModel.ToCategoryDto());
     }

     [HttpPut]
     [Route("{id:int}")]

     public async Task <IActionResult> Update([FromRoute] int id, [FromBody] CreateCategoryRequestDto categoryDto){
         if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var categoryModel = await _categoryRepository.UpdatedAsync(id,categoryDto);
        if(categoryModel == null){
            return NotFound();
        }
        return Ok(categoryModel.ToCategoryDto());

     }

     [HttpDelete]
     [Route("{id:int}")]
     public async Task<IActionResult> Delete([FromRoute]int id){
         if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var categoryModel = await _categoryRepository.DeletedAsync(id);
        if(categoryModel == null){
            return NotFound();
        }
     
        return NoContent();

     }
    }
}