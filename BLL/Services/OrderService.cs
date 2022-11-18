using AutoMapper;
using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> orders = new List<Order>{
          new Order{ Id = 1, Price = 500, Valuedate = DateTime.Now, CustomerId = 0, EmployeeId = 0 },
          new Order{ Id = 2, Price = 600, Valuedate = DateTime.Now, CustomerId = 0, EmployeeId = 0 }
        };
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<OrderDto>>> AddOrder(OrderDto orderDto)
        {
            var serviceRespone = new ServiceResponse<List<OrderDto>>();
            orders.Add(_mapper.Map<Order>(orderDto));
            serviceRespone.Data = orders.Select(c => _mapper.Map<OrderDto>(c)).ToList();
            return serviceRespone;
        }

        public async Task<ServiceResponse<List<OrderDto>>> GetOrders()
        {
            return new ServiceResponse<List<OrderDto>>
            {
                Data = orders.Select(c => _mapper.Map<OrderDto>(c)).ToList()

            };
        }

        public async Task<ServiceResponse<OrderDto>> GetOrder(int id)
        {
            var serviceRespone = new ServiceResponse<OrderDto>();
            var order = orders.FirstOrDefault(c => c.Id == id);
            serviceRespone.Data = _mapper.Map<OrderDto>(order);
            return serviceRespone;
        }
        public async Task<ServiceResponse<OrderDto>> UpdateOrder(OrderDto orderDto)
        {
            var serviceRespone = new ServiceResponse<OrderDto>();

            try
            {
                Order order = orders.First(c => c.Id == orderDto.Id);

                _mapper.Map(orderDto, order);

                serviceRespone.Data = _mapper.Map<OrderDto>(order);
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
        public async Task<ServiceResponse<List<OrderDto>>> DeleteOrder(int id)
        {
            var serviceRespone = new ServiceResponse<List<OrderDto>>();
            try
            {
                Order order = orders.First(c => c.Id == id);

                orders.Remove(order);

                serviceRespone.Data = orders.Select(c => _mapper.Map<OrderDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
    }
}
