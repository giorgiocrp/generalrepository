using GenericRepository.Interfaces;

namespace GenericRepository.Models
{
    public class Product : IBase
    {
        public int Id => ProductId;
         public int ProductId { get; set; }
        public string? Name { get; set; }      
        public override string? ToString() => Name;
    }
}