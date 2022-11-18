using AutoMapper;
using BLL.Dto;
using DAL.Entities;
using System.Linq;
namespace Market
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto> ();

            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();

            CreateMap<Order, OrderDto>();

            CreateMap<OrderDto, Order>();

            CreateMap<OrderDetails, OrderDetailsDto>();

            CreateMap<OrderDetailsDto, OrderDetails>();
        }
    }
}
