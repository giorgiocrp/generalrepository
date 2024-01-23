using GenericRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Data
{

    public class Context : DbContext
    {
        public DbSet<Product> Products{get;set;}
        public Context()
        {
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}