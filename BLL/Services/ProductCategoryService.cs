using BLL.Intefaces;
using DAL.Entities;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto;
using AutoMapper;

namespace BLL.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
      private static List<ProductCategory> productCategories = new List<ProductCategory>{
          new ProductCategory{ Name= "Xmichq", Describtion = "ALKOHOLAYIN", PictureRef = "C://img.jpg" },
          new ProductCategory{ Id = 1, Name= "Xmichq1", Describtion = "Voch ALKOHOLAYIN", PictureRef = "C://img1.jpg"}

    };
        private readonly IMapper _mapper;

        public ProductCategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductCategoryDto>>> AddProductCategory(ProductCategoryDto productCategory)
        {
            var serviceRespone = new ServiceResponse<List<ProductCategoryDto>>();
            productCategories.Add(_mapper.Map<ProductCategory>(productCategory));
            serviceRespone.Data = productCategories.Select(c=> _mapper.Map<ProductCategoryDto>(c)).ToList();
            return serviceRespone;
        }

        public async Task<ServiceResponse<List<ProductCategoryDto>>> GetProductCategories()
        {
            return new ServiceResponse<List<ProductCategoryDto>>
            {
                Data = productCategories.Select(c => _mapper.Map<ProductCategoryDto>(c)).ToList()

            };
        }

        public async Task<ServiceResponse<ProductCategoryDto>> GetProductCategory(int id)
        {
            var serviceRespone = new ServiceResponse<ProductCategoryDto>();
            var productCategory = productCategories.FirstOrDefault(c => c.Id == id);
            serviceRespone.Data =_mapper.Map<ProductCategoryDto>(productCategory);
            return serviceRespone;
        }

    }
}
