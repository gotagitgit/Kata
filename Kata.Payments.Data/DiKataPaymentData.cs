using Kata.Payments.Data.DataSeeder;
using Kata.Payments.Data.ProductPaymentRules;
using Kata.Payments.Data.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Payments.Data
{
    public static class DiKataPaymentData
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseContextSeeder, ProductsSeeder>();
            services.AddSingleton<IDatabaseContextSeeder, ProductPaymentRuleSeeder>();

            RegisterDaos(services);
        }

        private static void RegisterDaos(IServiceCollection services)
        {
            services.AddScoped<IProductDao, ProductDao>();
            services.AddScoped<IProductPaymentRuleDao, ProductPaymentRuleDao>();
        }
    }
}
