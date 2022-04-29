using System.Collections.Generic;
using System.Linq;
using Kata.Payments.Domain.Payments.Models;

namespace Kata.Payments.Domain.Payments.Factory
{
    public sealed class PaymentRuleFactory : IPaymentRuleFactory
    {
        private readonly Dictionary<PaymentRule, IPaymentRule> _rules;

        public PaymentRuleFactory(IEnumerable<IPaymentRule> paymentRules)
        {
            _rules = paymentRules.ToDictionary(x => x.PaymentRule, x => x);
        }

        public IPaymentRule Create(PaymentRule paymentRule)
        {
            return _rules[paymentRule];
        }
    }
}
