using System.Collections.Generic;
using Kata.SupermarketPricing.Models;

namespace Kata.SupermarketPricing.Services
{
    public sealed class ItemService : IItemService
    {
        public double ComputeCost(IEnumerable<Item> items)
        {
            double cost = 0;

            foreach (var item in items)
            {
                cost += item.ComputeItemCost();
            }

            return cost;
        }
    }
}
