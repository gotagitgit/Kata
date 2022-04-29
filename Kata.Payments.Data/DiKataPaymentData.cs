using Kata.Payments.Data.DataSeeder;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Payments.Data
{
    public static class DiKataPaymentData
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseContextSeeder, ProductsSeeder>();
            services.AddSingleton<IDatabaseContextSeeder, ProductPaymentRuleSeeder>();
        }
    }
}
