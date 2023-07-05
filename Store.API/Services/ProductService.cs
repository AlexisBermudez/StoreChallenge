using Store.API.Entities;
using Store.API.Repository;

namespace Store.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Product AddProduct(Product product)
        {
            return _repository.AddProduct(product);
        }

        public IEnumerable<Product> GetByDescription(string query)
        {
            return _repository.GetByDescription(query);
        }

        public Product GetProductById(long id)
        {
            return _repository.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetProducts();
        }

        public bool UpdateProduct(long id, Product editedProduct)
        {
            return _repository.UpdateProduct(id, editedProduct);
        }

        public bool DeleteProduct(long id)
        {
            return _repository.DeleteProduct(id);
        }
    }
}
