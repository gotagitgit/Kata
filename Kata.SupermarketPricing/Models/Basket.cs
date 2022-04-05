using System;
using System.Collections.Immutable;
using System.Linq;

namespace Kata.SupermarketPricing.Models
{
    public sealed class Basket
    {
        private Basket() : this(ImmutableList<BasketItem>.Empty)
        {
        }

        public Basket(ImmutableList<BasketItem> basketItems)
        {
            BasketItems = basketItems;
        }

        public static Basket Empty => new();

        public ImmutableList<BasketItem> BasketItems { get; }

        public double Total => Math.Round(BasketItems.Sum(x => x.ItemPrice), 2);       

        public Basket AddItem(BasketItem item)
        {
            if (TryUpdateExistingBasketItem(item, out var basket))
                return basket;

            var updatedBasketItems = BasketItems.Add(item);

            return new Basket(updatedBasketItems);
        }

        private bool TryUpdateExistingBasketItem(BasketItem item, out Basket basket)
        {
            basket = Basket.Empty;

            var builder = BasketItems.ToBuilder();

            var basketItem = builder.Find(x => x.Product.Id == item.Product.Id);

            if (basketItem == null)
                return false;
            
            var updatedBasketItem = basketItem.WithQuantity(item.Quantity);

            var basketItems = BasketItems.Replace(basketItem, updatedBasketItem);

            basket = new Basket(basketItems);

            return true;            
        }
    }
}
