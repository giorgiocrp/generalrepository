using GenericRepository.Data;
using GenericRepository.Interfaces;
using GenericRepository.Models;
using GenericRepository.Repositories.Base;

namespace GenericRepository.Repositories{
    public class ProductRepository:RepositoryBase<Product> {
           
        public ProductRepository(Context context):base(context)
        {
            
        }
        
    }
}