using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kata.SuperMarket.Data.StockPriceSchemes
{
    public sealed class StockPriceSchemeDao : IStockPriceSchemeDao
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StockPriceSchemeDao(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async ValueTask<List<StockPriceSchemeDto>> FindAllAsync()
        {
            return await _applicationDbContext.StockPriceSchemes.ToListAsync();
        }

        public async ValueTask<StockPriceSchemeDto> FindByStockIdAsync(Guid id)
        {
            return await _applicationDbContext.StockPriceSchemes.SingleOrDefaultAsync(x => x.StockId == id);
        }

        public async ValueTask<bool> InsertAsync(StockPriceSchemeDto stockPriceScheme)
        {
            await _applicationDbContext.StockPriceSchemes.AddAsync(stockPriceScheme);

            var created = await _applicationDbContext.SaveChangesAsync();

            return created > 0;
        }

        public async ValueTask<bool> UpdateAsync(StockPriceSchemeDto stockPriceScheme)
        {
            _applicationDbContext.StockPriceSchemes.Update(stockPriceScheme);

            var updated = await _applicationDbContext.SaveChangesAsync();

            return updated > 0;
        }

        public async ValueTask<bool> DeleteAsync(Guid id)
        {
            var stockPriceScheme = await FindStockPriceSchemeByIdAsync(id);

            if (stockPriceScheme == null)
                return false;

            _applicationDbContext.StockPriceSchemes.Remove(stockPriceScheme);

            var deleted = await _applicationDbContext.SaveChangesAsync();

            return deleted > 0;
        }

        private async ValueTask<StockPriceSchemeDto> FindStockPriceSchemeByIdAsync(Guid id)
        {
            return await _applicationDbContext.StockPriceSchemes.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
