using GenericRepository.Data;
using GenericRepository.Interfaces;
using GenericRepository.Models;
using GenericRepository.Repositories.Base;

namespace GenericRepository.Repositories{
    public class ProductRepository:RepositoryBase<Product> {
        private Context _context;
        private IRepositoryBase<Product> _repository { get; }

        public ProductRepository(Context context):base(context)
        {
            _context = context;
        }

        public ProductRepository(IRepositoryBase<Product> repository,Context context):base(context)
        {
            _repository=repository;
        }

        
    }
}