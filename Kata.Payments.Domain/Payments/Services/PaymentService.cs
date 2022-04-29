using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata.Payments.Domain.Payments.Factory;
using Kata.Payments.Domain.Payments.Models;

namespace Kata.Payments.Domain.Payments.Services
{
    public sealed class PaymentService
    {
        private readonly IPaymentRuleFactory _paymentRuleFactory;

        public PaymentService(IPaymentRuleFactory paymentRuleFactory)
        {
            _paymentRuleFactory = paymentRuleFactory;
        }

        public void ProcessPayment(Guid id)
        {
            // call repo to get product by id

            var product = new Product(Guid.NewGuid(), "", ProductType.Physical, ProductCategory.Book, new List<PaymentRule>());

            foreach (var item in product.PaymentRules)
            {
                var paymentRule = _paymentRuleFactory.Create(item);

                paymentRule.ExecuteRule(product);
            }
        }
    }
}
