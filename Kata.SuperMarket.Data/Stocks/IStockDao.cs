using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata.SuperMarket.Data.Stocks
{
    public interface IStockDao
    {
        Task<bool> DeleteAsync(Guid id);
        Task<List<StockDto>> FindAllAsync();
        Task<StockDto> FindAsync(Guid id);
        Task<bool> InsertAsync(StockDto stock);
        Task<bool> UpdateAsync(StockDto stock);
    }
}