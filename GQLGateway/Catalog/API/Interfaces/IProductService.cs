using Catalog.Domain;

namespace Catalog.API.Interfaces
{
    public interface IProductService
    {
        Product? GetProductById(int id);
        List<Product> GetProducts();
    }
}