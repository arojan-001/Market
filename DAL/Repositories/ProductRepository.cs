using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }

        public List<Product> GetProducts()
        {
            return GetAll();
        }

        public  Product GetProduct(int id)
        {
            List<Product> products = GetAll();
            return products.FirstOrDefault(c => c.Id == id);
        }

        public void AddProduct(Product product, bool isSaveChanges = true)
        {
            var dbProduct = Find(product.Id);
            if (dbProduct == null)
                Add(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public  Product DeleteProduct(int Id, bool isSaveChanges = true)
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
