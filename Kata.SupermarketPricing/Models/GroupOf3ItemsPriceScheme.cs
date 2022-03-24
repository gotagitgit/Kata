namespace Kata.SupermarketPricing.Models
{
    public sealed class GroupOf3ItemsPriceScheme : IPriceScheme
    {
        private const int ItemCount = 3;

        public double ComputeItemPrice(Product product, double quantity)
        {
            return (product.Price / ItemCount) * quantity;
        }
    }
}
