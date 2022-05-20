using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Models
{
    public sealed class MembershipPaymentRule : IPaymentRule
    {
        public PaymentRule PaymentRule => PaymentRule.NewMemberShipRule;

        public void ExecuteRule(Product product)
        {
            if (product is not MembershipProduct)
                return;

            var membershipProduct = (MembershipProduct)product;

            if (membershipProduct.IsMembershipUpgrade)
            {
                // Apply upgrade
            }
            else
            {
                // Activate Membership
            }

            // email owner of activation/upgrade.

        }
    }
}
