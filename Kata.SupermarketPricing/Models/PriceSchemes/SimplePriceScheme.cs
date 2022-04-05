namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public sealed class SimplePriceScheme : IPriceScheme
    {
        public double ComputeItemPrice(Product product, ItemMeasure itemMeasure)
        {
            return product.Price * itemMeasure.Quantity;
        }
    }
}
