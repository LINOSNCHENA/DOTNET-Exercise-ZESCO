using Microsoft.EntityFrameworkCore;
using Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microservice.Repository;
using ProductMicroservice.DBContexts;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
            var quantiaItens = _dbContext.Products.ToList();
            if (quantiaItens.Count == 0)
            {
                PopulaBanco();
            }
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public Product GetProductByID(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }

        public void PopulaBanco()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronic Items",
                Price = 1500
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            var product2 = new Product
            {
                Id = 2,
                Name = "Roupas",
                Description = "Roupas",
                Price = 1500
            };

            _dbContext.Products.Add(product2);
            _dbContext.SaveChanges();

            var product3 = new Product
            {
                Id = 3,
                Name = "Tenis",
                Description = "Tenis",
                Price = 1500
            };

            _dbContext.Products.Add(product3);
            _dbContext.SaveChanges();
        }
    }
}