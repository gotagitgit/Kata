using Kata.Payments.Domain.ProductPaymentRules.Factory;
using Kata.Payments.Domain.ProductPaymentRules.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Payments.Domain.ProductPaymentRules
{
    public static class DiProductPaymentRule
    {
        public static void Configure(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterFactories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductPaymentRuleRepository, ProductPaymentRuleRepository>();
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<IProductPaymentRuleFactory, ProductPaymentRuleFactory>();
        }
    }
}
