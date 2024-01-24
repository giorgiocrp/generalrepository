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



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Xunit;
// using Moq;
// using Microsoft.EntityFrameworkCore;
// using GenericRepository.Data;
// using GenericRepository.Models;
// using GenericRepository.Repositories;
// using TestGenericRepository.Utils;
// using Microsoft.EntityFrameworkCore.Query;
// using System.Linq.Expressions;


// namespace TestGenericRepository
// {
//     public class ProductRepositoryTest
//     {

//         [Fact]
//         public void Count_ReturnsCorrectCount()
//         {
//             // Arrange
//             var products = new List<Product>
//             {
//                 new Product { ProductId = 1, Name = "Product1" },
//                 new Product { ProductId = 2, Name = "Product2" },
//                 new Product { ProductId = 3, Name = "Product3" },
//             };

//             var mockSet = new Mock<DbSet<Product>>();
//             mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.AsQueryable().Provider);
//             mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.AsQueryable().Expression);
//             mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.AsQueryable().ElementType);
//             mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.AsQueryable().GetEnumerator());

//             var mockContext = new Mock<Context>();
//             mockContext.Setup(c => c.Set<Product>()).Returns(mockSet.Object);

//             var productRepository = new ProductRepository(mockContext.Object);

//             // Act
//             var result = productRepository.Count();

//             // Assert
//             Assert.Equal(3, result); // Change the expected count based on your test data
//         }

//         [Fact]
//         public async Task CountAsync_ReturnsCorrectCountAsync()
//         {
//             // Arrange
//             var products = new List<Product>
//             {
//                 new Product { ProductId = 1, Name = "Product1" },
//                 new Product { ProductId = 2, Name = "Product2" },
//                 new Product { ProductId = 3, Name = "Product3" },
//             };

//             var mockSet = new Mock<DbSet<Product>>();
//             var queryable = products.AsQueryable();

//             mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryable.Provider);
//             mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryable.Expression);
//             mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
//             mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

//             var mockContext = new Mock<Context>();
//             mockContext.Setup(c => c.Set<Product>()).Returns(mockSet.Object);

//             var productRepository = new ProductRepository(mockContext.Object);

//             // Act
//             var result = await productRepository.CountAsync();

//             // Assert
//             Assert.Equal(3, result); // Change the expected count based on your test data
//         }
//     }
// }