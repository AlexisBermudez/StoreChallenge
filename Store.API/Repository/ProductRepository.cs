﻿using Store.API.Context;
using Store.API.Models;

namespace Store.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext _storeContext;

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

        public void AddProduct(Product product)
        {
            _storeContext.Products.Add(product);
            _storeContext.SaveChanges();
        }

        public void UpdateProduct(long id, Product editedProduct)
        {
            editedProduct.Id = id;
            var product = _storeContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _storeContext.Entry<Product>(product).CurrentValues.SetValues(editedProduct);
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
