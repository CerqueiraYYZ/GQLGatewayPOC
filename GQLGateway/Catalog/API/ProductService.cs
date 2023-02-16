using Catalog.API.Interfaces;

namespace Catalog.Domain
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        { return new List<Product>() { new Product() { Id = 1, Name = "GQL", Brand = new Brand() { Id = 2, Name = "GQL Brand" } } }; }
        public Product? GetProductById(int id)
        {
            return new Product() { Id = 1, Name = "GQL", Brand = new Brand() { Id = 2, Name = "GQL Brand" } };
        }
    }
}
