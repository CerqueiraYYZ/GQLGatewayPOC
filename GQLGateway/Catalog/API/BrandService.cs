using Catalog.API.Interfaces;

namespace Catalog.Domain
{
    public class BrandService : IBrandService
    {
        public List<Brand> GetBrands()
        {
            return new List<Brand>() { new Brand() { Id = 1, Name = "brands" } };
        }
    }
}
