using AutoMapper;
using Store.API.Entities;
using Store.API.Models;

namespace Store.API.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile() 
        { 
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
