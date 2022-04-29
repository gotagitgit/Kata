using Kata.Payments.Domain.Products.Factory;
using Kata.Payments.Domain.Products.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Payments.Domain.Payments
{
    public static class DiPayments
    {
        public static void Configure(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterFactories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();            
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<IProductFactory, ProductFactory>();
        }
    }
}
