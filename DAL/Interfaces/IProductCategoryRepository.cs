using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetProductCategories();
        Task<ProductCategory> GetProductCategory(int id);
        Task<ProductCategory> AddProductCategory(ProductCategory productCategory);


    }
}

