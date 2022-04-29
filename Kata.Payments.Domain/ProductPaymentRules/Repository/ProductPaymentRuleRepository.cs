using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Kata.Payments.Data.ProductPaymentRules;
using Kata.Payments.Domain.ProductPaymentRules.Factory;
using Kata.Payments.Domain.ProductPaymentRules.Models;

namespace Kata.Payments.Domain.ProductPaymentRules.Repository
{
    public sealed class ProductPaymentRuleRepository : IProductPaymentRuleRepository
    {
        private readonly IProductPaymentRuleDao _productPaymentRuleDao;
        private readonly IProductPaymentRuleFactory _productPaymentRuleFactory;

        public ProductPaymentRuleRepository(
            IProductPaymentRuleDao productPaymentRuleDao,
            IProductPaymentRuleFactory productPaymentRuleFactory)
        {
            _productPaymentRuleDao = productPaymentRuleDao;
            _productPaymentRuleFactory = productPaymentRuleFactory;
        }

        public async ValueTask<ImmutableList<ProductPaymentRule>> FindByProductIdAsync(Guid id)
        {
            var productPaymentRuleDtos = await _productPaymentRuleDao.FindByProductIdAsync(id);

            return productPaymentRuleDtos.Select(_productPaymentRuleFactory.ToModel).ToImmutableList();
        }
    }
}
