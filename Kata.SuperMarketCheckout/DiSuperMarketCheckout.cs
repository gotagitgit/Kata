using Kata.SuperMarket.Data;
using Kata.SuperMarketCheckout.Checkouts;
using Kata.SuperMarketCheckout.StockPriceSchemes;
using Kata.SuperMarketCheckout.Stocks;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SuperMarketCheckout
{
    public sealed class DiSuperMarketCheckout
    {
        public static void Configure(IServiceCollection services)
        {
            DiCheckout.Configure(services);
            DiStockPriceScheme.Configure(services);
            DiStock.Configure(services);
            DiSuperMarketData.Configure(services);
        }
    }
}
