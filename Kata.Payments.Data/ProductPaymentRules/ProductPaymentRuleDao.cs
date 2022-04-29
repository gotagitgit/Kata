using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kata.Payments.Data.ProductPaymentRules
{
    public sealed class ProductPaymentRuleDao : IProductPaymentRuleDao
    {
        private readonly KataPaymentDbContext _dbContext;

        public ProductPaymentRuleDao(KataPaymentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<ProductPaymentRuleDto>> FindAllAsync()
        {
            return _dbContext.ProductPaymentRules.ToListAsync();
        }

        public async Task<ProductPaymentRuleDto> FindAsync(Guid id)
        {
            return await FindProductPaymentRuleByIdAsync(id);
        }

        public async Task<List<ProductPaymentRuleDto>> FindByProductIdAsync(Guid id)
        {
            return await _dbContext.ProductPaymentRules.Where(x => x.ProductId == id).ToListAsync();
        }

        public async Task<bool> InsertAsync(ProductPaymentRuleDto stock)
        {
            await _dbContext.ProductPaymentRules.AddAsync(stock);

            var created = await _dbContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateAsync(ProductPaymentRuleDto stock)
        {
            _dbContext.ProductPaymentRules.Update(stock);

            var updated = await _dbContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var stock = await FindProductPaymentRuleByIdAsync(id);

            if (stock == null)
                return false;

            _dbContext.ProductPaymentRules.Remove(stock);

            var deleted = await _dbContext.SaveChangesAsync();

            return deleted > 0;
        }

        private async Task<ProductPaymentRuleDto> FindProductPaymentRuleByIdAsync(Guid id)
        {
            return await _dbContext.ProductPaymentRules.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
