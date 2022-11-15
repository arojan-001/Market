using Microsoft.AspNetCore.Mvc;
using BLL.Intefaces;
using BLL.Infrastructure;
using BLL.Dto;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryservice;

        public ProductCategoryController(IProductCategoryService productCategoryservice)
        {
            _productCategoryservice = productCategoryservice;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<ProductCategoryDto>>> Get()
        {
            return Ok(await _productCategoryservice.GetProductCategories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductCategoryDto>>> GetSingle(int id)
        {
            return Ok(await _productCategoryservice.GetProductCategory(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProductCategoryDto>>>> AddProductCategory(ProductCategoryDto productCategory)
        {
            return Ok(await _productCategoryservice.AddProductCategory(productCategory));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<ProductCategoryDto>>> UpdateProductCategory(ProductCategoryDto productCategory)
        {
            var response = await _productCategoryservice.UpdateProductCategory(productCategory);
            if( response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProductCategoryDto>>>> DeleteProductCategory(int id)
        {
            var response = await _productCategoryservice.DeleteProductCategory(id);
            if (response.Data == null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
