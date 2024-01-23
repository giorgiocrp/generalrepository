using GenericRepository.Data;
using GenericRepository.Interfaces;
using GenericRepository.Models;
using GenericRepository.Repositories.Base;

namespace GenericRepository.Repositories{
    public class ProductRepository:RepositoryBase<Product> {
        private Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
    }
}