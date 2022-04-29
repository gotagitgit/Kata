using Kata.Payments.Data.ProductPaymentRules;
using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Factory
{
    public interface IProductPaymentRuleFactory
    {
        ProductPaymentRule ToModel(ProductPaymentRuleDto dto);
    }
}