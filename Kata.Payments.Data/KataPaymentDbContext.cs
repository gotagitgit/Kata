using Kata.Payments.Data.ProductPaymentRules;
using Kata.Payments.Data.Products;
using Microsoft.EntityFrameworkCore;

namespace Kata.Payments.Data
{
    public sealed class KataPaymentDbContext : DbContext
    {
        public KataPaymentDbContext(DbContextOptions<KataPaymentDbContext> options) : base(options)
        {
        }

        public DbSet<ProductDto> Products { get; set; }

        public DbSet<ProductPaymentRuleDto> ProductPaymentRules { get; set; }
    }
}
