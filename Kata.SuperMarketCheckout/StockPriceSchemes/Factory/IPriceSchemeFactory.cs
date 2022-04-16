using System;
using System.Threading.Tasks;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public interface IPriceSchemeFactory
    {
        ValueTask<IPriceScheme> CreateAsync(Guid id);
    }
}