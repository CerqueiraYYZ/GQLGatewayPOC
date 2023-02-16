using Bag.API;

using HotChocolate;

namespace Bag.Queries
{
    public class MutationBag
    {
        public Domain.Bag? AddToBag(int id, int productId, int quantity, [Service] BagService bagRepository) =>
        bagRepository.AddToBag(id, productId, quantity);
    }
}
