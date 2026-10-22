using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Task_1.DTOs;
using Task_1.Services;

namespace Task_1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<ProductV1Dto>> GetAllV1()
        {
            return Ok(_productService.GetAllV1());
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("1.0")]
        public ActionResult<ProductV1Dto> GetByIdV1(int id)
        {
            var product = _productService.GetByIdV1(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<IEnumerable<ProductV2Dto>> GetAllV2()
        {
            return Ok(_productService.GetAllV2());
        }

        [HttpGet("{id:int}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ProductV2Dto> GetByIdV2(int id)
        {
            var product = _productService.GetByIdV2(id);
            return product is null ? NotFound() : Ok(product);
        }

        
    }
}
