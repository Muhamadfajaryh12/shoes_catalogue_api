using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dtos.Shoes;
using Microsoft.AspNetCore.Mvc;

namespace api.controller
{
    public class ShoesController
    {
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult>GetById([FromRoute] int id)
        {

        }

        [HttpPost]
        public async Task<IActionResult>Create([FromBody] CreateShoesRequestDto shoesDto){

        }

        [HttpPut]
        [Route("{id:int}")]


        [HttpDelete]
        [Route("{id:int}")]
    }
}