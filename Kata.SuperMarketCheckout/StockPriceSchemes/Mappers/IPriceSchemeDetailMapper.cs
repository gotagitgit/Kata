using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Mappers
{
    public interface IPriceSchemeDetailMapper
    {
        PriceScheme PriceScheme { get; }

        IPriceSchemeDetail ToDetail(string xml);
    }
}