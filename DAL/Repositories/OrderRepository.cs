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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context) { }

        public List<Order> GetOrders()
        {
            return GetAll();
        }

        public Order GetOrder(int id)
        {
            return Find(id);
        }

        public void AddOrder(Order order, bool isSaveChanges = true)
        {
            var dbProduct = Find(order.Id);
            if (dbProduct == null)
                Add(order);
            else
                SetValues(order, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public Order DeleteOrder(int Id, bool isSaveChanges = true)
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
