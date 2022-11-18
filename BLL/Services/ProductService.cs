using AutoMapper;
using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>{
          new Product{ Id = 1, Name = "Fanta", ProductCategoryId = 1, PriceOfUnit = 300, Qnty = 10},
          new Product{ Id = 2, Name = "Gini", ProductCategoryId = 2, PriceOfUnit = 5600, Qnty = 12}

    };
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductDto>>> AddProduct(ProductDto productDto)
        {
            var serviceRespone = new ServiceResponse<List<ProductDto>>();
            products.Add(_mapper.Map<Product>(productDto));
            serviceRespone.Data = products.Select(c => _mapper.Map<ProductDto>(c)).ToList();
            return serviceRespone;
        }

        public async Task<ServiceResponse<List<ProductDto>>> GetProducts()
        {
            return new ServiceResponse<List<ProductDto>>
            {
                Data = products.Select(c => _mapper.Map<ProductDto>(c)).ToList()

            };
        }

        public async Task<ServiceResponse<ProductDto>> GetProduct(int id)
        {
            var serviceRespone = new ServiceResponse<ProductDto>();
            var product = products.FirstOrDefault(c => c.Id == id);
            serviceRespone.Data = _mapper.Map<ProductDto>(product);
            return serviceRespone;
        }
        public async Task<ServiceResponse<ProductDto>> UpdateProduct(ProductDto productDto)
        {
            var serviceRespone = new ServiceResponse<ProductDto>();

            try
            {
                Product product = products.First(c => c.Id == productDto.Id);

                _mapper.Map(productDto, product);

                serviceRespone.Data = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
        public async Task<ServiceResponse<List<ProductDto>>> DeleteProduct(int id)
        {
            var serviceRespone = new ServiceResponse<List<ProductDto>>();
            try
            {
                Product product = products.First(c => c.Id == id);

                products.Remove(product);

                serviceRespone.Data = products.Select(c => _mapper.Map<ProductDto>(c)).ToList();
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
