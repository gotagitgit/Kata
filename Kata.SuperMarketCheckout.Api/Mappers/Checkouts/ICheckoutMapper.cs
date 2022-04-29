using Kata.SuperMarketCheckout.Api.Dtos.Checkouts;
using Kata.SuperMarketCheckout.Checkouts.Models;

namespace Kata.SuperMarketCheckout.Api.Mappers.Checkouts
{
    public interface ICheckoutMapper
    {
        CheckoutDto ToDto(Checkout checkout);
        CheckoutItem ToModel(CheckoutItemDto dto);
    }
}