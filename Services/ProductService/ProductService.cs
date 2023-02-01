using BawlAPI.Dtos.Product;
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

            public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto product)
            {
                var serviceResponse = new ServiceResponse<List<GetProductDto>>();
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Products.ToListAsync();
                return serviceResponse;
            }

            public async Task<ServiceResponse<List<GetProductDto>>> Get()
            {
                return new ServiceResponse<List<GetProductDto>> { Data = await _context.Products.ToListAsync() };
            } 

            public async Task<ServiceResponse<GetProductDto>> GetProduct(int id)
            {
                var serviceResponse = new ServiceResponse<GetProductDto>();
                serviceResponse.Data = await _context.Products.FindAsync(id);              
                return  serviceResponse;


            }

            public async Task<ServiceResponse<List<GetProductDto>>> UpdateProduct(Product request)
            {
                var serviceResponse = new ServiceResponse<List<GetProductDto>>();
                serviceResponse.Data = await _context.Products.ToListAsync();
                return serviceResponse;
            }

   
    }
}
