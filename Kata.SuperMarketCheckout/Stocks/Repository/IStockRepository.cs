using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Stocks.Repository
{
    public interface IStockRepository
    {
        ValueTask<IList<Stock>> FindAllAsync();
        ValueTask<Stock> FindAsync(Guid id);
    }
}