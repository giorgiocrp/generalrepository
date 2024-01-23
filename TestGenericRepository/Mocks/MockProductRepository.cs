using GenericRepository.Interfaces;
using GenericRepository.Models;
using GenericRepository.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGenericRepository.Mocks
{
    internal class MockProductRepository
    {
        public static Mock<IRepositoryBase<Product>> GetMock() 
        { 
            
            var mock= new Mock<IRepositoryBase<Product>>();

            mock.Setup(m => m.Update(It.IsAny<Product>())).Callback(() => { return; });
            mock.Setup(m => m.Remove(It.IsAny<Product>())).Callback(() => { return; });

            mock.Setup(m => m.Add(It.IsAny<Product>())).Callback(() => { return; });
            mock.Setup(m => m.AddRange(It.IsAny<IEnumerable<Product>>())).Callback(() => { return; });
            mock.Setup(m => m.Count()).Returns(() => { return 10; });
            //mock.Setup(m => m.CountAsync()).Returns(() => { return 10; });
            //mock.Setup(m => m.Get(It.IsAny<Product>())).Callback(() => { return; });
            //mock.Setup(m => m.GetAsync(It.IsAny<Product>())).Callback(() => { return; });
            mock.Setup(m => m.GetAll()).Callback(() => { return; });
            mock.Setup(m => m.GetAllAsync()).Callback(() => { return; });           
            mock.Setup(m => m.GetId(It.IsAny<int>())).Callback(() => { return; });
            mock.Setup(m => m.GetIdAsync(It.IsAny<int>())).Callback(() => { return; });
            //mock.Setup(m => m.GetList(It.IsAny<Product>())).Callback(() => { return; });
            //mock.Setup(m => m.GetListAsync(It.IsAny<Product>())).Callback(() => { return; });

            

            return mock;
        }
    }
}
