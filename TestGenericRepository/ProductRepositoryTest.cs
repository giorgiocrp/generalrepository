using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using GenericRepository.Data;
using GenericRepository.Models;
using GenericRepository.Repositories;

namespace TestGenericRepository
{
    public class ProductRepositoryTest
    {
        
        [Fact]
         public void Count_ReturnsCorrectCount()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new Context(dbContextOptions))
            {
                var productRepository = new ProductRepository(context);

                // Add some test data
                var products = new List<Product>
                {
                    new Product { ProductId = 1, Name = "Product1" },
                    new Product { ProductId = 2, Name = "Product2" },
                    new Product { ProductId = 3, Name = "Product3" },
                };

                context.Products.AddRange(products);
                context.SaveChanges();

                // Act
                var result = productRepository.Count();

                // Assert
                Assert.Equal(3, result); // Change the expected count based on your test data
            }
        }
    }
}