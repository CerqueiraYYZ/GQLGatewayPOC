using Catalog.API.Interfaces;
using Catalog.Domain;

using HotChocolate;

namespace Catalog.Queries
{
    public class QueryBrand
    {
        public IEnumerable<Brand> GetBrands([Service] IBrandService brandRepository) =>
        brandRepository.GetBrands();
    }
}
