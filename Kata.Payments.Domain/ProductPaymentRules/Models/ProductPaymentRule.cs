using System;

namespace Kata.Payments.Domain.ProductPaymentRules.Models
{
    public sealed class ProductPaymentRule
    {
        public ProductPaymentRule(
            Guid id,
            Guid productId,
            PaymentRule paymentRule)
        {
            Id = id;
            ProductId = productId;
            PaymentRule = paymentRule;
        }

        public Guid Id { get; }

        public Guid ProductId { get; }

        public PaymentRule PaymentRule { get; }
    }
}
