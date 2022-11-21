using AutoMapper;
using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        //private static List<Product> products = new List<Product>{
        //  new Product{ Id = 1, Name = "Fanta", ProductCategoryId = 1, PriceOfUnit = 300, Qnty = 10},
        //  new Product{ Id = 2, Name = "Gini", ProductCategoryId = 2, PriceOfUnit = 5600, Qnty = 12}};
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        public ProductService(IMapper mapper, IProductRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<ProductDto>>> AddProduct(ProductDto productDto)
        {
            var serviceRespone = new ServiceResponse<List<ProductDto>>();
            try
            {
                _repository.AddProduct(_mapper.Map<Product>(productDto));
                serviceRespone.Data = _repository.GetProducts().Select(c => _mapper.Map<ProductDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }

        public async Task<ServiceResponse<List<ProductDto>>> GetProducts()
        {
            return new ServiceResponse<List<ProductDto>>
            {
                Data = _repository.GetProducts().Select(c => _mapper.Map<ProductDto>(c)).ToList()

            };
        }

        public async Task<ServiceResponse<ProductDto>> GetProduct(int id)
        {
            var serviceRespone = new ServiceResponse<ProductDto>();
            try
            {
                var product = _repository.GetProduct(id);
                serviceRespone.Data = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
        public async Task<ServiceResponse<ProductDto>> UpdateProduct(ProductDto productDto)
        {
            var serviceRespone = new ServiceResponse<ProductDto>();

            try {
                Product product = _repository.GetProduct(productDto.Id);

                _mapper.Map(productDto, product);
                _repository.AddProduct(product);
                serviceRespone.Data = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex){
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
                Product product = _repository.GetProduct(id);

                _repository.DeleteProduct(id);

                serviceRespone.Data = _repository.GetProducts().Select(c => _mapper.Map<ProductDto>(c)).ToList();
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
