using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Repository
{
    public interface IProductPaymentRuleRepository
    {
        ValueTask<ImmutableList<ProductPaymentRule>> FindByProductIdAsync(Guid id);
    }
}