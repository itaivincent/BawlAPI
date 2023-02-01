using BawlAPI.Dtos.Product;
using BawlAPI.Models;

namespace BawlAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> Get();
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(Product product);
        Task<ServiceResponse<List<GetProductDto>>> UpdateProduct(Product request);
        Task<ServiceResponse<GetProductDto>>  GetProduct(int id);
    }
}
