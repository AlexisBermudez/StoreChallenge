﻿using Store.API.Entities;

namespace Store.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext ?? throw new ArgumentNullException(nameof(storeContext));
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

        public bool UpdateProduct(long id, Product editedProduct)
        {
            editedProduct.Id = id;
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _storeContext.Entry(product).CurrentValues.SetValues(editedProduct);
                _storeContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProduct(long id)
        {
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Product removed = _storeContext.Products.Remove(product).Entity;
                _storeContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
