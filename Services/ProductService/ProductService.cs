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

            public async Task<ServiceResponse<List<Product>>> AddProduct(Product product)
            {
            var serviceResponse = new ServiceResponse<List<Product>>();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Products.ToListAsync();
            return serviceResponse;
            }

            public async Task<ServiceResponse<List<Product>>> Get()
            {
                return new ServiceResponse<List<Product>> { Data = await _context.Products.ToListAsync() };
            }

            public async Task<ServiceResponse<Product>> GetProduct(int id)
            {
                var product = await _context.Products.FindAsync(id);              
                return product;

            }

            public async Task<ServiceResponse<List<Product>>> UpdateProduct(Product request)
            {
                return await _context.Products.ToListAsync();
            }

   
    }
}
