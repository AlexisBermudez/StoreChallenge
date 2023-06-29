using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.API.Entities;
using Store.API.Models;
using Store.API.Repository;
using Store.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(_productService.GetProducts()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            ProductDto product = _mapper.Map<ProductDto>(_productService.GetProductById(id));
            return product == null ? NoContent() : Ok(product);
        }

        [HttpGet("search")]
        public IActionResult GetByDescription([FromQuery]string q)
        {
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(_productService.GetByDescription(q)));
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductDto product)
        {
            try
            {
                ProductDto created = _mapper.Map<ProductDto>(_productService.AddProduct(_mapper.Map<Product>(product)));
                string locationUri = $"{Request.Host}/api/product/{created.Id}";
                return Created(locationUri, created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto editedProduct)
        {
            try
            {
                _productService.UpdateProduct(id, _mapper.Map<Product>(editedProduct));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
