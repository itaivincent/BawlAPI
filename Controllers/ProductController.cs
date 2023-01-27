using BawlAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BawlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> products = new List<Product>
            {
                new Product {
                    Id = 1,
                    Name = "Flannel shirt",
                    Description = "Green thick flannel",
                    Price = 20,CreatedAt="27 Jan 2023",
                    CategoryId = 2,
                    DiscountId = 4,
                    InventoryId = 23
                }
            };

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<List<Product>> AddProduct(Product product)
        {
            products.Add(product);
            return Ok(products);
        }

        [HttpPut]
        public ActionResult<List<Product>> UpdateProduct(Product request)
        {
            var product = products.Find(h => h.Id == request.Id);
            if (product == null)
                return BadRequest("The product you are looking for is not there!!!");
            
            //write code to override the current object of the selected product!!!

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.Find(h => h.Id == id);
            if (product == null)
                return BadRequest("The product you are looking for is not there!!!");
            return Ok(product);
        }

    }
}
