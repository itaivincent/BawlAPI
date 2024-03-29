﻿using BawlAPI.Dtos.Product;
using BawlAPI.Models;
using BawlAPI.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BawlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //dependency injection for the ProductService that is doing all the logic for our methods
        private readonly IProductService _productService;    
        public ProductController(IProductService productService)
        {
            _productService = productService;            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _productService.Get();
                return StatusCode(200, result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
                          
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> AddProduct(AddProductDto product)
        {   
            return Ok( await _productService.AddProduct(product));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> UpdateProduct(Product request)
        {
            //var product = products.Find(h => h.Id == request.Id);
            //if (product == null)

            //    return BadRequest("The product you are looking for is not there!!!");
            
            ////write code to override the current object of the selected product!!!

            return Ok( _productService.Get());

        }

        //this is the method for getting a single model of the product the execution is in the ProductService Class
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetProduct(int id)
        {
            return Ok( await _productService.GetProduct(id));
        }

    }
}
