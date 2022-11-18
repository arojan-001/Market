using BLL.Dto;
using BLL.Infrastructure;
using BLL.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<ProductDto>>> Get()
        {
            return Ok(await _productservice.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductDto>>> GetSingle(int id)
        {
            return Ok(await _productservice.GetProduct(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProductDto>>>> AddProduct(ProductDto productDto)
        {
            return Ok(await _productservice.AddProduct(productDto));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ProductDto>>> UpdateProduct(ProductDto productDto)
        {
            var response = await _productservice.UpdateProduct(productDto);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProductDto>>>> DeleteProduct(int id)
        {
            var response = await _productservice.DeleteProduct(id);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
