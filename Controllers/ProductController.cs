using BawlAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BawlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        //dataContext injection through the constructor, also the method will recognise the DataContext elememt witout adding the using keyword to import the Context
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
           _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
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
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return BadRequest("The product you are looking for is not there!!!");
            return Ok(product);
        }

    }
}
