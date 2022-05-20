using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Models
{
    public interface IPaymentRule
    {
        PaymentRule PaymentRule { get; }

        void ExecuteRule(Product product);
    }
}