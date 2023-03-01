using AutoMapper;
using BawlAPI.Dtos.Product;
using BawlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BawlAPI.Services.ProductService
{
    public class ProductService : IProductService
    {
        //dataContext injection through the constructor, also the method will recognise the DataContext elememt witout adding the using keyword to import the Context

            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public ProductService(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto product)
            {
                var serviceResponse = new ServiceResponse<List<GetProductDto>>();
                _context.Products.Add(_mapper.Map<Product>(product));
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Products.Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
                return serviceResponse; 

            }


        //public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto product)
        //{
        //    var serviceResponse = new ServiceResponse<List<GetProductDto>>();
        //    _context.Products.Add(_mapper.Map<Product>(product));
        //    await _context.SaveChangesAsync();
        //    serviceResponse.Data = await _context.Products.Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
        //    return serviceResponse;

        //}

             public  List<Product> Get()
            {
              // var list =  new ServiceResponse<List<Product>> { Data =  _context.Products.ToList() };
                 var list =  _context.Products.ToList();
                 return list; 
            } 

            public async Task<ServiceResponse<GetProductDto>> GetProduct(int id)
            {
            var serviceResponse = new ServiceResponse<GetProductDto>
            {
                Data = _mapper.Map<GetProductDto>( _context.Products.FirstOrDefault(c => c.Id == id))
            };
            return  serviceResponse; 
            }
      
            public async Task<ServiceResponse<List<GetProductDto>>> UpdateProduct(UpdateProductDto request)
            {
                var serviceResponse = new ServiceResponse<List<GetProductDto>>();
                serviceResponse.Data = await _context.Products.Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
                return serviceResponse;
            }

    }
}
