using BawlAPI.Models;

namespace BawlAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> Get();
        Task<ServiceResponse<List<Product>>> AddProduct(Product product);
        Task<ServiceResponse<List<Product>>> UpdateProduct(Product request);
        Task<ServiceResponse<Product>>  GetProduct(int id);
    }
}
