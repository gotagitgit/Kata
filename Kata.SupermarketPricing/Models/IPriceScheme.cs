namespace Kata.SupermarketPricing.Models
{
    public interface IPriceScheme
    {
        double ComputeItemPrice(Product product, double quantity);
    }
}