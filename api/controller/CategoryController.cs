using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data;
using api.dtos.Category;
using api.mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.controller
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
     public CategoryController(ApplicationDBContext context)
     {
      _context  = context;  
     }   

     [HttpGet]

     public IActionResult GetAll(){
        var category = _context.Category.ToList().Select(item=>item.ToCategoryDto());
        return Ok(category); 
     }

     [HttpGet("{id}")]

     public IActionResult GetById([FromRoute] int id){
        var category = _context.Category.Find(id);

        if(category == null){
            return NotFound();
        }
        return Ok(category);
     }  

     [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryRequestDto categoryDto){
        var categoryModel =categoryDto.ToCategoryFromCreateDTO();
        _context.Category.Add(categoryModel);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = categoryModel.id}, categoryModel.ToCategoryDto());
     }

     [HttpPut]
     [Route("{id}")]

     public IActionResult Update([FromRoute] int id, [FromBody] CreateCategoryRequestDto categoryDto){
        var categoryModel = _context.Category.FirstOrDefault(x=> x.id == id);
        if(categoryModel == null){
            return NotFound();
        }
        categoryModel.CategoryName = categoryDto.CategoryName;
        _context.SaveChanges();
        return Ok(categoryModel.ToCategoryDto());

     }
    }
}