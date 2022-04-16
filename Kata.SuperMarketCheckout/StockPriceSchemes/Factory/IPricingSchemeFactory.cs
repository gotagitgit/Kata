using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public interface IPricingSchemeFactory
    {
        PriceScheme PriceScheme { get; }

        IPriceScheme Create(StockPriceScheme stockPriceScheme);
    }
}