using System;
using System.Collections.Immutable;
using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.Products.Models
{
    public sealed class MembershipProduct : Product
    {
        public MembershipProduct(
            Guid id,
            string name,
            ProductType productType,
            ProductCategory category,
            ImmutableList<PaymentRule> paymentRules,
            bool isMembershipUpgrade) : base(id, name, productType, category, paymentRules)
        {
            IsMembershipUpgrade = isMembershipUpgrade;
        }

        public bool IsMembershipUpgrade { get; }
    }
}
