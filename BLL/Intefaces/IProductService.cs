using BLL.Dto;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductDto>>> GetProducts();
        Task<ServiceResponse<ProductDto>> GetProduct(int id);
        Task<ServiceResponse<List<ProductDto>>> AddProduct(ProductDto productDto);
        Task<ServiceResponse<ProductDto>> UpdateProduct(ProductDto productDto);
        Task<ServiceResponse<List<ProductDto>>> DeleteProduct(int id);
    }
}
