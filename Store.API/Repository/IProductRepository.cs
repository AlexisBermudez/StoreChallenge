﻿using Store.API.Context;
using Store.API.Entities;

namespace Store.API.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductById(long id);
        public IEnumerable<Product> GetByDescription(string query);
        public Product AddProduct(Product product);
        public void UpdateProduct(long id, Product editedProduct);
        public void DeleteProduct(long id);
    }
}
