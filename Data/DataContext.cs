using BawlAPI.Dtos.Product;
using BawlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BawlAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        // we have to use a DBset property to see a representation of tables in our database 
        public DbSet<GetProductDto> Products { get; set; }
    }
}
