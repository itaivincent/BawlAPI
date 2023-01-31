using BawlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BawlAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        //dataContext injection through the constructor, also the method will recognise the DataContext elememt witout adding the using keyword to import the Context

            private readonly DataContext _context;
            public ProductService(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> AddProduct(Product product)
            {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return await _context.Products.ToListAsync();
            }

            public async Task<List<Product>> Get()
            {
                return await _context.Products.ToListAsync();
            }

            public async Task<Product> GetProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);              
                return product;

            }

            public async Task<List<Product>> UpdateProduct(Product request)
            {
                return await _context.Products.ToListAsync();
            }

   
    }
}
