using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DataContext context) : base(context) { }
        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await GetAll();
        }
        public async Task<ProductCategory> GetProductCategory(int id)
        {
            List<ProductCategory> productCategories = await GetAll();
            return productCategories.FirstOrDefault(c => c.Id == id);
        }
        public async Task<ProductCategory> AddProductCategory(ProductCategory productCategory)
        {
            ProductCategory _productCategory = (ProductCategory) await Add(productCategory);
            return _productCategory;
        }

    }
}
