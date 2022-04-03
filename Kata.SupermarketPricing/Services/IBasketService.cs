using System.Collections.Generic;
using Kata.SupermarketPricing.Models;

namespace Kata.SupermarketPricing.Services
{
    public interface IBasketService
    {
        double ComputeCost(IEnumerable<BasketItem> items);
    }
}