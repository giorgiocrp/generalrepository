using AutoMapper;
using GenericRepository.Data;
using GenericRepository.Models;
using GenericRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using TestGenericRepository.Mocks;

namespace TestGenericRepository
{
    public class ProductRepositoryTest
    {

        [Fact]
        public void TestCountMethod()
        {
            var mock = MockProductRepository.GetMock();

            var context=new Context();

            var repository = new ProductRepository(mock.Object,context);

            //Assert

            var result = repository.Count();
            Assert.Equal(10, result);

        }
    }
}