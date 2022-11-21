using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Order GetOrder(int id);
        void AddOrder(Order order, bool isSaveChanges = true);
        Order DeleteOrder(int Id, bool isSaveChanges = true);
    }
}
