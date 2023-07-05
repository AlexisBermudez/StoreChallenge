using AutoMapper;
using Store.API.Entities;
using Store.API.Models;

namespace Store.API
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
