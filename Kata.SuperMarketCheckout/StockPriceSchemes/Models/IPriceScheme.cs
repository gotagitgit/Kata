using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Models
{
    public interface IPriceScheme
    {
        decimal ComputeCost(StockItem stockItem);
    }
}