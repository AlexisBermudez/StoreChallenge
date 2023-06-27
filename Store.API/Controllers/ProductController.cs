using Microsoft.AspNetCore.Mvc;
using Store.API.Models;
using Store.API.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;

        public ProductController(ProductRepository productService)
        {
            _productRepository = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productRepository.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {

            Product product = _productRepository.GetProductById(id);
            return product == null ? NoContent() : Ok(product);
        }

        [HttpGet("search")]
        public IActionResult GetByDescription([FromQuery]string q)
        {
            return Ok(_productRepository.GetByDescription(q));
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            try
            {
                _productRepository.AddProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product editedProduct)
        {
            try
            {
                _productRepository.UpdateProduct(id, editedProduct);
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
                _productRepository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
