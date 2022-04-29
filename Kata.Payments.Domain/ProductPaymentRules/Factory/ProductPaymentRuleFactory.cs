using Kata.Payments.Data.ProductPaymentRules;
using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Factory
{
    public sealed class ProductPaymentRuleFactory : IProductPaymentRuleFactory
    {
        public ProductPaymentRule ToModel(ProductPaymentRuleDto dto)
        {
            return new ProductPaymentRule(
                dto.Id,
                dto.ProductId,
                (PaymentRule)dto.PaymentRule);
        }
    }
}
