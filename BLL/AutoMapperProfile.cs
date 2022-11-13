using AutoMapper;
using BLL.Dto;
using DAL.Entities;
using System.Linq;
namespace BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto> ();

            CreateMap<ProductCategoryDto, ProductCategory>();
        }
    }
}
