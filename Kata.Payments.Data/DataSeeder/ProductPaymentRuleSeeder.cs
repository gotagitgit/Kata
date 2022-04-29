using System;
using System.Collections.Generic;
using System.Linq;
using Kata.Payments.Data.ProductPaymentRules;
using Microsoft.EntityFrameworkCore;

namespace Kata.Payments.Data.DataSeeder
{
    public sealed class ProductPaymentRuleSeeder : IDatabaseContextSeeder
    {
        public void Seed(DbContext dbContext)
        {
            if (dbContext is KataPaymentDbContext kataPaymentDbContext)
            {
                if (kataPaymentDbContext.ProductPaymentRules.Any())
                    return;

                var productPaymentRules = CreatProductPaymentRules();

                kataPaymentDbContext.AddRange(productPaymentRules);

                kataPaymentDbContext.SaveChanges();
            }
        }

        private List<ProductPaymentRuleDto> CreatProductPaymentRules()
        {
            return new List<ProductPaymentRuleDto>
            {
                new ProductPaymentRuleDto
                {
                    Id = new Guid("2a3b25e0-9b90-40a0-8644-e955cc6d2301"),
                    ProductId = ProductsSeeder.NewMembershipProductId,
                    PaymentRule = 1,
                },
                new ProductPaymentRuleDto
                {
                    Id = new Guid("3403e42a-b338-4375-a130-15649d2b72fe"),
                    ProductId = ProductsSeeder.UpgradeMembershipProductId,
                    PaymentRule = 2
                }
            };
        }
    }
}
