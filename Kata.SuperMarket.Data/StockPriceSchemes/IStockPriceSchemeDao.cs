using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata.SuperMarket.Data.StockPriceSchemes
{
    public interface IStockPriceSchemeDao
    {
        ValueTask<bool> DeleteAsync(Guid id);
        ValueTask<List<StockPriceSchemeDto>> FindAllAsync();
        ValueTask<StockPriceSchemeDto> FindByStockIdAsync(Guid id);
        ValueTask<bool> InsertAsync(StockPriceSchemeDto stockPriceScheme);
        ValueTask<bool> UpdateAsync(StockPriceSchemeDto stockPriceScheme);
    }
}