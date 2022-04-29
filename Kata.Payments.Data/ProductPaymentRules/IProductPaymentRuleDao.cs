using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kata.Payments.Data.ProductPaymentRules
{
    public interface IProductPaymentRuleDao
    {
        Task<bool> DeleteAsync(Guid id);
        Task<List<ProductPaymentRuleDto>> FindAllAsync();
        Task<ProductPaymentRuleDto> FindAsync(Guid id);
        Task<List<ProductPaymentRuleDto>> FindByProductIdAsync(Guid id);
        Task<bool> InsertAsync(ProductPaymentRuleDto stock);
        Task<bool> UpdateAsync(ProductPaymentRuleDto stock);
    }
}