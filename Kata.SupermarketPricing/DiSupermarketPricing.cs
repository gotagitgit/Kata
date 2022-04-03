using Kata.SupermarketPricing.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SupermarketPricing
{
    public static class DiSupermarketPricing
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBasketService, BasketService>();
        }
    }
}
