using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Infrastructure;
using BLL.Dto;

namespace BLL.Intefaces
{
    public interface IProductCategoryService
    {
        Task<ServiceResponse<List<ProductCategoryDto>>> GetProductCategories();
        Task<ServiceResponse<ProductCategoryDto>> GetProductCategory(int id);
        Task<ServiceResponse<List<ProductCategoryDto>>> AddProductCategory(ProductCategoryDto productCategory);
        Task<ServiceResponse<ProductCategoryDto>> UpdateProductCategory(ProductCategoryDto productCategoryDto);
        Task<ServiceResponse<List<ProductCategoryDto>>> DeleteProductCategory(int id);
    }
}
