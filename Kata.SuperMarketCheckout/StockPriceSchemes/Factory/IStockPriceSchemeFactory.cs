using Kata.SuperMarket.Data.StockPriceSchemes;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public interface IStockPriceSchemeFactory
    {
        StockPriceScheme ToModel(StockPriceSchemeDto dto);
    }
}