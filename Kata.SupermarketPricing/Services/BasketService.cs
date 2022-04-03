using System.Collections.Generic;
using System.Collections.Immutable;
using Kata.SupermarketPricing.Models;

namespace Kata.SupermarketPricing.Services
{
    public sealed class BasketService : IBasketService
    {
        private readonly Basket _basket;

        public BasketService()
        {
            _basket = new Basket(ImmutableList<BasketItem>.Empty);
        }

        public double ComputeCost(IEnumerable<BasketItem> items)
        {
            double cost = 0;

            return cost;
        }

        public Basket AddItem(BasketItem item)
        {
            return _basket.AddItem(item);
        }
    }
}
