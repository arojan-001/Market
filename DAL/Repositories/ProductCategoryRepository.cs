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
            return GetAll();
        }
        public async Task<ProductCategory> GetProductCategory(int id)
        {
            return Find(id);
        }

        public async Task<ProductCategory> AddProductCategory(ProductCategory productCategory)
        {
            ProductCategory _productCategory = (ProductCategory) Add(productCategory);
            return _productCategory;
        }
        public async  void AddProductCategory(ProductCategory productCategory, bool isSaveChanges = true)
        {
            var dbProduct = Find(productCategory.Id);
            if (dbProduct == null)
                Add(productCategory);
            else
                SetValues(productCategory, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public async Task<ProductCategory> DeleteProductCategory(int Id, bool isSaveChanges = true)
        {
            var dbEntry = Find(Id);
            if (dbEntry != null)
            {
                Remove(dbEntry);
                if (isSaveChanges)
                    SaveChanges();
            }
            return dbEntry;
        }

    }
}
