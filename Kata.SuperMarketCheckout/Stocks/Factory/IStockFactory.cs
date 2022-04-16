using System.Threading.Tasks;
using Kata.SuperMarket.Data.Stocks;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Stocks.Factory
{
    public interface IStockFactory
    {        
        ValueTask<Stock> ToModelAsync(StockDto dto);
    }
}