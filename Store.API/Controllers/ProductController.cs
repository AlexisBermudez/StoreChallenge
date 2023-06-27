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
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(long id)
        {
            return _productRepository.GetProductById(id);
        }

        [HttpGet("search")]
        public IEnumerable<Product> GetByDescription([FromQuery]string q)
        {
            return _productRepository.GetByDescription(q);
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _productRepository.AddProduct(product);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product editedProduct)
        {
            _productRepository.UpdateProduct(id, editedProduct);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
