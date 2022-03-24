using System.Collections.Generic;
using System.Linq;

namespace Kata.SupermarketPricing.Models
{
    public sealed class Basket
    {
        public Basket(IList<BasketItem> basketItems)
        {
            BasketItems = basketItems;
        }

        public IList<BasketItem> BasketItems { get; }

        public double Total => BasketItems.Sum(x => x.ItemPrice);
    }
}
