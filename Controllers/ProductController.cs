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
        public ActionResult<List<Product>> Get()
        {
            return Ok(_productService.Get());
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product product)
        {   
            return Ok(_productService.AddProduct(product));
        }

        [HttpPut]
        public ActionResult<List<Product>> UpdateProduct(Product request)
        {
            //var product = products.Find(h => h.Id == request.Id);
            //if (product == null)
            //    return BadRequest("The product you are looking for is not there!!!");
            
            ////write code to override the current object of the selected product!!!

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return Ok(_productService.GetProduct(id));
        }

    }
}
