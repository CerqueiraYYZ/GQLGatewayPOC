using Catalog.API.Interfaces;
using Catalog.Domain;
using HotChocolate;

namespace Catalog.Queries
{
    public class QueryProduct
    {
        public IEnumerable<Product>? GetProducts([Service] IProductService productRepository) =>
        productRepository.GetProducts();

        public Product? GetProductById(int id, [Service] IProductService productRepository) =>
            productRepository.GetProductById(id);
    }
}
