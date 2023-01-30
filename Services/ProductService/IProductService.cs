using BawlAPI.Models;

namespace BawlAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> Get();
        List<Product> AddProduct(Product product);
        List<Product> UpdateProduct(Product request);
        Product GetProduct(int id);
    }
}
