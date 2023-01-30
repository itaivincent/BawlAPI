using BawlAPI.Models;

namespace BawlAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> Get();
        Task<List<Product>> AddProduct(Product product);
        Task<List<Product>> UpdateProduct(Product request);
        Product GetProduct(int id);
    }
}
