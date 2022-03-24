using System.Collections.Generic;
using Kata.SupermarketPricing.Models;

namespace Kata.SupermarketPricing.Services
{
    public interface IItemService
    {
        double ComputeCost(IEnumerable<BasketItem> items);
    }
}