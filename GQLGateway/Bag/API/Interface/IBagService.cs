namespace Bag.API.Interface
{
    public interface IBagService
    {
        Domain.Bag? AddToBag(int id, int productId, int quantity);
        Domain.Bag? GetBagById(int id);
        Domain.Bag? GetBagByUsername(string name);
    }
}