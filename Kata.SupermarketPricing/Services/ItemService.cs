using System;
using System.Collections.Generic;
using Kata.SupermarketPricing.Models;

namespace Kata.SupermarketPricing.Services
{
    public sealed class ItemService : IItemService
    {
        public double ComputeCost(IEnumerable<BasketItem> items)
        {
            double cost = 0;

            return cost;
        }

        public List<BasketItem> AddItem(BasketItem item)
        {
            throw new NotImplementedException();
        }
    }
}
