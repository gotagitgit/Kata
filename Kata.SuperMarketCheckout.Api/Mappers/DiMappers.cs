using Kata.SuperMarketCheckout.Api.Mappers.Checkouts;

namespace Kata.SuperMarketCheckout.Api.Mappers
{
    public static class DiMappers
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<ICheckoutMapper, CheckoutMapper>();
        }
    }
}
