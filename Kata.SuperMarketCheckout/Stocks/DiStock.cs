using Kata.SuperMarketCheckout.Stocks.Factory;
using Kata.SuperMarketCheckout.Stocks.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SuperMarketCheckout.Stocks
{
    public static class DiStock
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IStockFactory, StockFactory>();
            services.AddScoped<IStockRepository, StockRepository>();            
        }
    }
}
