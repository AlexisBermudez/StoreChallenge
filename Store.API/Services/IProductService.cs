using Store.API.Entities;

namespace Store.API.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(long id);
        public IEnumerable<Product> GetByDescription(string query);
        public Product AddProduct(Product product);
        public bool UpdateProduct(long id, Product editedProduct);
        public bool DeleteProduct(long id);
    }
}
