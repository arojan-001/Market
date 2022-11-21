using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderDetailsRepository
    {
        List<OrderDetails> GetOrderDetails();
        OrderDetails GetOrderDetail(int id);
        void AddOrderDetail(OrderDetails order, bool isSaveChanges = true);
        OrderDetails DeleteOrderDetail(int Id, bool isSaveChanges = true);
    }
}
