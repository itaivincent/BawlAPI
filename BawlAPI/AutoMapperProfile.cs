using AutoMapper;
using BawlAPI.Dtos.Product;
using BawlAPI.Models;

namespace BawlAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<AddProductDto, Product>();
        }
    }
}
