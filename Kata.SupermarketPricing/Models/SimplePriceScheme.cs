namespace Kata.SupermarketPricing.Models
{
    public sealed class SimplePriceScheme : IPriceScheme
    {
        public double ComputeItemPrice(Product product, double quantity)
        {
            return product.Price * quantity;
        }
    }
}
