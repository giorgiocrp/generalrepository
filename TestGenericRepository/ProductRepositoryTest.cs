using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GenericRepository.Data;
using GenericRepository.Models;
using GenericRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GenericRepository.Tests
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void Add_Product_Should_Call_Context_Add_And_SaveChanges()
        {
            // Arrange
            var product = new Product();
            var contextMock = new Mock<Context>();
            var dbSetMock = new Mock<DbSet<Product>>();

            contextMock.Setup(c => c.Set<Product>()).Returns(dbSetMock.Object);

            var repository = new ProductRepository(contextMock.Object);

            // Act
            repository.Add(product);

            // Assert
            dbSetMock.Verify(d => d.Add(product), Times.Once);
            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void GetAll_Should_Return_All_Products()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product1" },
                new Product { ProductId = 2, Name = "Product2" },
            };

            var contextMock = new Mock<Context>();
            var repository = new ProductRepository(contextMock.Object);

            contextMock.Setup(c => c.Set<Product>()).Returns(MockDbSetHelper.GetMockDbSet(products));

            // Act
            var result = repository.GetAll();

            // Assert
            Assert.Equal(products, result);
        }

        [Fact]
        public void Count_Should_Return_Count_Products()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product1" },
                new Product { ProductId = 2, Name = "Product2" },
            };

            var contextMock = new Mock<Context>();
            var repository = new ProductRepository(contextMock.Object);

            contextMock.Setup(c => c.Set<Product>()).Returns(MockDbSetHelper.GetMockDbSet(products));

            // Act
            var result = repository.Count();

            // Assert
            Assert.Equal(products.Count(), result);
        }
    }

    internal static class MockDbSetHelper
    {
        internal static Microsoft.EntityFrameworkCore.DbSet<T> GetMockDbSet<T>(List<T> data) where T : class
        {
            var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }
    }
}