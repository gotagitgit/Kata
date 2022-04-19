using Kata.SuperMarketCheckout.StockPriceSchemes.Factory;
using Kata.SuperMarketCheckout.StockPriceSchemes.Mappers;
using Kata.SuperMarketCheckout.StockPriceSchemes.Repository.cs;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SuperMarketCheckout.StockPriceSchemes
{
    public class DiStockPriceScheme
    {
        public static void Configure(IServiceCollection services)
        {
            RegisterFactories(services);
            RegisterMappers(services);
            RegisterRepositories(services);
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<IPriceSchemeFactory, PriceSchemeFactory>();
            services.AddScoped<IPricingSchemeFactory, BundledPriceSchemeFactory>();
            services.AddScoped<IPricingSchemeFactory, BuyAndGetFreeItemsPriceSchemeFactory>();
            services.AddScoped<IStockPriceSchemeFactory, StockPriceSchemeFactory>();
        }

        private static void RegisterMappers(IServiceCollection services)
        {
            services.AddScoped<IPriceSchemeDetailMapper, BundledPriceSchemeDetailMapper>();
            services.AddScoped<IPriceSchemeDetailMapper, BuyAndGetFreePriceSchemeDetailMapper>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IStockPriceSchemeRepository, StockPriceSchemeRepository>();
        }
    }
}
