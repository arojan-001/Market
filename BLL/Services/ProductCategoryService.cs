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
using DAL.Interfaces;

namespace BLL.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
      private static List<ProductCategory> productCategories = new List<ProductCategory>{
          new ProductCategory{ Id = 2, Name= "Xmichq", Describtion = "ALKOHOLAYIN", PictureRef = "C://img.jpg" },
          new ProductCategory{ Id = 1, Name= "Xmichq1", Describtion = "Voch ALKOHOLAYIN", PictureRef = "C://img1.jpg"}

    };
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _repository;
        public ProductCategoryService(IMapper mapper, IProductCategoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductCategoryDto>>> AddProductCategory(ProductCategoryDto productCategory)
        {
            var serviceRespone = new ServiceResponse<List<ProductCategoryDto>>();
            //productCategories.Add(_mapper.Map<ProductCategory>(productCategory));
            var v = await _repository.AddProductCategory(_mapper.Map<ProductCategory>(productCategory));
            serviceRespone.Data = productCategories.Select(c=> _mapper.Map<ProductCategoryDto>(c)).ToList();
            return serviceRespone;
        }

        public async Task<ServiceResponse<List<ProductCategoryDto>>> GetProductCategories()
        {
            List<ProductCategory> productCategories = await _repository.GetProductCategories();
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
        public async Task<ServiceResponse<ProductCategoryDto>> UpdateProductCategory(ProductCategoryDto productCategoryDto)
        {
            var serviceRespone = new ServiceResponse<ProductCategoryDto>();

            try {
                ProductCategory productCategory = productCategories.FirstOrDefault(c => c.Id == productCategoryDto.Id);

                _mapper.Map(productCategoryDto, productCategory);
                //productCategory.Name = productCategoryDto.Name;
                //productCategory.Describtion = productCategoryDto.Describtion;
                //productCategory.PictureRef = productCategoryDto.PictureRef;

                serviceRespone.Data = _mapper.Map<ProductCategoryDto>(productCategory);
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
        public async Task<ServiceResponse<List<ProductCategoryDto>>> DeleteProductCategory(int id)
        {
            var serviceRespone = new ServiceResponse<List<ProductCategoryDto>>();
            try
            {
                ProductCategory productCategory = productCategories.First(c => c.Id == id);

                productCategories.Remove(productCategory);

                serviceRespone.Data = productCategories.Select(c => _mapper.Map<ProductCategoryDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }

    }
}
