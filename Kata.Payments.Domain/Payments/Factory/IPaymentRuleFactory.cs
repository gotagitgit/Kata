using Kata.Payments.Domain.Payments.Models;

namespace Kata.Payments.Domain.Payments.Factory
{
    public interface IPaymentRuleFactory
    {
        IPaymentRule Create(PaymentRule paymentRule);
    }
}