using Store.API.Context;
using Store.API.Entities;

namespace Store.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _storeContext.Products;
        }

        public Product GetProductById(long id)
        {
            return _storeContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByDescription(string query)
        {
            return _storeContext.Products.Where(p => p.Description.Contains(query));
        }

        public Product AddProduct(Product product)
        {
            Product created = _storeContext.Products.Add(product).Entity;
            _storeContext.SaveChanges();
            return created;
        }

        public void UpdateProduct(long id, Product editedProduct)
        {
            editedProduct.Id = id;
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _storeContext.Entry(product).CurrentValues.SetValues(editedProduct);
                _storeContext.SaveChanges();
            }
        }

        public void DeleteProduct(long id)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _storeContext.Products.Remove(product);
                _storeContext.SaveChanges();
            }
        }
    }
}
