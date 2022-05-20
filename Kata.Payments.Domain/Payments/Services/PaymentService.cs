using System;
using System.Threading.Tasks;
using Kata.Payments.Domain.ProductPaymentRules.Factory;
using Kata.Payments.Domain.Products.Repository;

namespace Kata.Payments.Domain.Products.Services
{
    public sealed class PaymentService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPaymentRuleFactory _paymentRuleFactory;

        public PaymentService(
            IProductRepository productRepository,
            IPaymentRuleFactory paymentRuleFactory)
        {
            _productRepository = productRepository;
            _paymentRuleFactory = paymentRuleFactory;
        }

        public async Task ProcessPaymentAsync(Guid id)
        {
            var product = await _productRepository.FindAsync(id);

            foreach (var item in product.PaymentRules)
            {
                var paymentRule = _paymentRuleFactory.Create(item);

                paymentRule.ExecuteRule(product);
            }
        }
    }
}
