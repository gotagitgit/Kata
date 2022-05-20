using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Factory
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
            if (_rules.TryGetValue(paymentRule, out var rule))
                return rule;

            throw new ArgumentException($"{paymentRule} is not implemented");
        }
    }
}
