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
        void AddProductCategory(ProductCategory productCategory, bool isSaveChanges = true);
        Task<ProductCategory> DeleteProductCategory(int Id, bool isSaveChanges = true);

    }
}

