using Catalog.Domain;

namespace Catalog.API.Interfaces
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
    }
}