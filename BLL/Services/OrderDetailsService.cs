using AutoMapper;
using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        //private static List<OrderDetails> orderDetails = new List<OrderDetails>{
        //  new OrderDetails{ Id = 1, OrderId = 1, Quantity = 5, Price = 500 },
        //  new OrderDetails{ Id = 2, OrderId = 2, Quantity = 7, Price = 500 }
        //};
        private readonly IMapper _mapper;
        private readonly IOrderDetailsRepository _repository;
        public OrderDetailsService(IMapper mapper, IOrderDetailsRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<OrderDetailsDto>>> AddOrderDetails(OrderDetailsDto orderDetailsDto)
        {
            var serviceRespone = new ServiceResponse<List<OrderDetailsDto>>();
            try
            {
                _repository.AddOrderDetail(_mapper.Map<OrderDetails>(orderDetailsDto));
                serviceRespone.Data = _repository.GetOrderDetails().Select(c => _mapper.Map<OrderDetailsDto>(c)).ToList();
            }
            catch (Exception ex) {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }

        public async Task<ServiceResponse<List<OrderDetailsDto>>> GetOrderDetails()
        {
            return new ServiceResponse<List<OrderDetailsDto>>
            {
                Data = _repository.GetOrderDetails().Select(c => _mapper.Map<OrderDetailsDto>(c)).ToList()

            };
        }

        public async Task<ServiceResponse<OrderDetailsDto>> GetOrderDetailById(int id)
        {
            var serviceRespone = new ServiceResponse<OrderDetailsDto>();
            try
            {
                serviceRespone.Data = _mapper.Map<OrderDetailsDto>(_repository.GetOrderDetail(id));
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
        public async Task<ServiceResponse<OrderDetailsDto>> UpdateOrderDetails(OrderDetailsDto orderDetailsDto)
        {
            var serviceRespone = new ServiceResponse<OrderDetailsDto>();

            try
            {
                OrderDetails orderDetail = _repository.GetOrderDetail(orderDetailsDto.Id);

                 _mapper.Map(orderDetailsDto, orderDetail);
                _repository.AddOrderDetail(orderDetail);
                serviceRespone.Data = _mapper.Map<OrderDetailsDto>(orderDetail);
            }
            catch (Exception ex)
            {
                serviceRespone.Error = ex.Message;
                serviceRespone.Success = false;
            }
            return serviceRespone;
        }
        public async Task<ServiceResponse<List<OrderDetailsDto>>> DeleteOrderDetails(int id)
        {
            var serviceRespone = new ServiceResponse<List<OrderDetailsDto>>();
            try
            {
                _repository.DeleteOrderDetail(id);

                serviceRespone.Data = _repository.GetOrderDetails().Select(c => _mapper.Map<OrderDetailsDto>(c)).ToList();
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
