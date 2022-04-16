using Kata.SuperMarketCheckout.Checkouts.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.SuperMarketCheckout.Checkouts
{
    public static class DiCheckout
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICheckoutService, CheckoutService>();
        }
    }
}
