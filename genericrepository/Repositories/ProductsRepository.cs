using GenericRepository.Data;
using GenericRepository.Interfaces;
using GenericRepository.Models;
using GenericRepository.Repositories.Base;

namespace GenericRepository.Repositories{
    public class ProductRepository:RepositoryBase<Product>,IProductRepository {
           
        public ProductRepository(Context context):base(context)
        {
            
        }
        
    }
}