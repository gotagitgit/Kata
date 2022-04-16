using System;
using System.Threading.Tasks;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Repository.cs
{
    public interface IStockPriceSchemeRepository
    {
        ValueTask<StockPriceScheme> FindByStockIdAsync(Guid id);
    }
}