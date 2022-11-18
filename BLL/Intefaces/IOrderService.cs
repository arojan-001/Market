using BLL.Dto;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IOrderService
    {
        Task<ServiceResponse<List<OrderDto>>> GetOrders();
        Task<ServiceResponse<OrderDto>> GetOrder(int id);
        Task<ServiceResponse<List<OrderDto>>> AddOrder(OrderDto orderDto);
        Task<ServiceResponse<OrderDto>> UpdateOrder(OrderDto orderDto);
        Task<ServiceResponse<List<OrderDto>>> DeleteOrder(int id);
    }
}
