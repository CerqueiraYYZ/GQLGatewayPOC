using Bag.API.Interface;
using HotChocolate;

namespace Bag.Queries
{
    public class QueryBag
    {
        public Domain.Bag? GetBagById(int id, [Service] IBagService bagRepository) =>
        bagRepository.GetBagById(id);

        public Domain.Bag? GetBagByUsername(string username, [Service] IBagService bagRepository) =>
            bagRepository.GetBagByUsername(username);
    }
}
