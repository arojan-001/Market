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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(DataContext context) : base(context) { }

        public List<OrderDetails> GetOrderDetails()
        {
            return GetAll();
        }

        public OrderDetails GetOrderDetail(int id)
        {
            return Find(id);
        }

        public void AddOrderDetail(OrderDetails orderDetail, bool isSaveChanges = true)
        {
            var dbProduct = Find(orderDetail.Id);
            if (dbProduct == null)
                Add(orderDetail);
            else
                SetValues(orderDetail, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public OrderDetails DeleteOrderDetail(int Id, bool isSaveChanges = true)
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
