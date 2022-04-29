using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kata.SuperMarket.Data.Stocks
{
    public sealed class StockDao : IStockDao
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StockDao(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<StockDto>> FindAllAsync()
        {
            return _applicationDbContext.Stocks.ToListAsync();
        }

        public async Task<StockDto> FindAsync(Guid id)
        {
            return await FindStockByIdAsync(id);
        }

        public async Task<bool> InsertAsync(StockDto stock)
        {
            await _applicationDbContext.Stocks.AddAsync(stock);

            var created = await _applicationDbContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateAsync(StockDto stock)
        {
            _applicationDbContext.Stocks.Update(stock);

            var updated = await _applicationDbContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var stock = await FindStockByIdAsync(id);

            if (stock == null)
                return false;

            _applicationDbContext.Stocks.Remove(stock);

            var deleted = await _applicationDbContext.SaveChangesAsync();

            return deleted > 0;
        }

        private async Task<StockDto> FindStockByIdAsync(Guid id)
        {
            return await _applicationDbContext.Stocks.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
