using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsDto>>> Get()
        {
            return Ok(await _orderDetailsService.GetOrderDetails());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsDto>>> GetSingle(int id)
        {
            return Ok(await _orderDetailsService.GetOrderDetailById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<OrderDetailsDto>>>> AddOrderDetails(OrderDetailsDto orderDetailsDto)
        {
            return Ok(await _orderDetailsService.AddOrderDetails(orderDetailsDto));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<OrderDetailsDto>>> UpdateOrderDetails(OrderDetailsDto orderDetailsDto)
        {
            var response = await _orderDetailsService.UpdateOrderDetails(orderDetailsDto);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<OrderDetailsDto>>>> DeleteOrderDetails(int id)
        {
            var response = await _orderDetailsService.DeleteOrderDetails(id);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
