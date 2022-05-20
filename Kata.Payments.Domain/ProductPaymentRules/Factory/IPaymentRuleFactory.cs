using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Factory
{
    public interface IPaymentRuleFactory
    {
        IPaymentRule Create(PaymentRule paymentRule);
    }
}