using Kata.SuperMarket.Data.DataSeeder;
using Kata.SuperMarket.Data.StockPriceSchemes;
using Kata.SuperMarket.Data.Stocks;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SuperMarket.Data
{
    public static class DiSuperMarketData
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IDataContextSeeder, StockSeeder>();
            services.AddScoped<IDataContextSeeder, StockPriceSchemeSeeder>();

            ConfigureDao(services);
        }

        private static void ConfigureDao(IServiceCollection services)
        {
            services.AddScoped<IStockDao, StockDao>();
            services.AddScoped<IStockPriceSchemeDao, StockPriceSchemeDao>();
        }
    }
}
