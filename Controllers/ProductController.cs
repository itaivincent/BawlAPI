using BawlAPI.Dtos.Product;
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
        public async Task<ActionResult<ServiceResponse<List<GetProductDto>>>> Get()
        {
            return Ok( await _productService.Get());



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

            return Ok(await _productService.Get()  );

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetProduct(int id)
        {
            return Ok( await _productService.GetProduct(id));
        }

    }
}
