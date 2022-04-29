using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata.Payments.Domain.Products.Factory;
using Kata.Payments.Domain.Products.Models;
using Kata.Payments.Domain.Products.Repository;

namespace Kata.Payments.Domain.Products.Services
{
    public sealed class PaymentService
    {
        private readonly IProductRepository _productRepository;

        public PaymentService(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ProcessPaymentAsync(Guid id)
        {
            var product = await _productRepository.FindAsync(id);

            //foreach (var item in product.PaymentRules)
            //{
            //    var paymentRule = _paymentRuleFactory.Create(item);

            //    paymentRule.ExecuteRule(product);
            //}
        }
    }
}
