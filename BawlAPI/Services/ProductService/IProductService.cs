using BawlAPI.Dtos.Product;
using BawlAPI.Models;

namespace BawlAPI.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Get();
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto product);
        Task<ServiceResponse<List<GetProductDto>>> UpdateProduct(UpdateProductDto request);
        Task<ServiceResponse<GetProductDto>>  GetProduct(int id);
    }
}
