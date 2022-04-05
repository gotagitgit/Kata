namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public sealed class SimplePriceScheme : IPriceScheme
    {
        public double ComputeItemPrice(Product product, double quantity)
        {
            return product.Price * quantity;
        }

        public double ComputeItemPriceWithUOM(Product product, double quantity, double uomConversion)
        {
            throw new System.NotImplementedException();
        }
    }
}
