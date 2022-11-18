using BLL.Dto;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IOrderDetailsService
    {
        Task<ServiceResponse<List<OrderDetailsDto>>> GetOrderDetails();
        Task<ServiceResponse<OrderDetailsDto>> GetOrderDetailById(int id);
        Task<ServiceResponse<List<OrderDetailsDto>>> AddOrderDetails(OrderDetailsDto orderDetailsDto);
        Task<ServiceResponse<OrderDetailsDto>> UpdateOrderDetails(OrderDetailsDto orderDetailsDto);
        Task<ServiceResponse<List<OrderDetailsDto>>> DeleteOrderDetails(int id);
    }
}
