using Bag.API.Interface;

namespace Bag.API
{
    public class BagService : IBagService
    {
        public Domain.Bag? GetBagById(int id)
        { return new Domain.Bag() { Id = 1, Name = "bagname" }; }

        public Domain.Bag? GetBagByUsername(string name)
        { return new Domain.Bag() { Id = 1, Name = "bagnameGetName" }; }

        public Domain.Bag? AddToBag(int id, int productId, int quantity)
        { return new Domain.Bag() { Id = 1, Name = "addbag" }; }
    }
}
