using System.Collections.Generic;
using System.Threading.Tasks;
using Kata.SuperMarketCheckout.Checkouts.Models;

namespace Kata.SuperMarketCheckout.Checkouts.Service
{
    public interface ICheckoutService
    {
        ValueTask<Checkout> CheckoutItemsAsync(IList<CheckoutItem> checkoutItems);
    }
}