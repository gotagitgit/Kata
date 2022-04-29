using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kata.Payments.Data.Products
{
    public sealed class ProductDao : IProductDao
    {
        private readonly KataPaymentDbContext _dbContext;

        public ProductDao(KataPaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ProductDto>> FindAllAsync()
        {
            return _dbContext.Products.ToListAsync();
        }

        public async Task<ProductDto> FindAsync(Guid id)
        {
            return await FindProductByIdAsync(id);
        }

        public async Task<bool> InsertAsync(ProductDto stock)
        {
            await _dbContext.Products.AddAsync(stock);

            var created = await _dbContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateAsync(ProductDto stock)
        {
            _dbContext.Products.Update(stock);

            var updated = await _dbContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var stock = await FindProductByIdAsync(id);

            if (stock == null)
                return false;

            _dbContext.Products.Remove(stock);

            var deleted = await _dbContext.SaveChangesAsync();

            return deleted > 0;
        }

        private async Task<ProductDto> FindProductByIdAsync(Guid id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
