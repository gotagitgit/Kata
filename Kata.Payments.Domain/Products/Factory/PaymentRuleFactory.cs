//using System.Collections.Generic;
//using System.Linq;
//using Kata.Payments.Domain.Products.Models;

//namespace Kata.Payments.Domain.Products.Factory
//{
//    public sealed class PaymentRuleFactory : IPaymentRuleFactory
//    {
//        private readonly Dictionary<PaymentRule, IPaymentRule> _rules;

//        public PaymentRuleFactory(IEnumerable<IPaymentRule> paymentRules)
//        {
//            _rules = paymentRules.ToDictionary(x => x.PaymentRule, x => x);
//        }

//        public IPaymentRule Create(PaymentRule paymentRule)
//        {
//            return _rules[paymentRule];
//        }
//    }
//}
