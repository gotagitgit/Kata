using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Kata.Payments.Data.Products;
using Kata.Payments.Domain.ProductPaymentRules.Repository;
using Kata.Payments.Domain.Products.Models;

namespace Kata.Payments.Domain.Products.Factory
{
    public sealed class ProductFactory : IProductFactory
    {
        private readonly IProductPaymentRuleRepository _productPaymentRuleRepository;

        public ProductFactory(IProductPaymentRuleRepository productPaymentRuleRepository)
        {
            _productPaymentRuleRepository = productPaymentRuleRepository;
        }

        public async ValueTask<Product> ToModelAsync(ProductDto dto)
        {
            var productPaymentRules = await _productPaymentRuleRepository.FindByProductIdAsync(dto.Id);

            var paymentRules = productPaymentRules.Select(x => x.PaymentRule).ToImmutableList();

            return new Product(
                dto.Id,
                dto.Name,
                (ProductType)dto.ProductType,
                (ProductCategory)dto.Category,
                paymentRules);
        }
    }
}
