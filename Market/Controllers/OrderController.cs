using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;

        public OrderController(IOrderService  orderService)
        {
            _orderservice = orderService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<OrderDto>>> Get()
        {
            return Ok(await _orderservice.GetOrders());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderDto>>> GetSingle(int id)
        {
            return Ok(await _orderservice.GetOrder(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<OrderDto>>>> AddOrder(OrderDto orderDto)
        {
            return Ok(await _orderservice.AddOrder(orderDto));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<OrderDto>>> UpdateOrder(OrderDto orderDto)
        {
            var response = await _orderservice.UpdateOrder(orderDto);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<OrderDto>>>> DeleteOrder(int id)
        {
            var response = await _orderservice.DeleteOrder(id);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
