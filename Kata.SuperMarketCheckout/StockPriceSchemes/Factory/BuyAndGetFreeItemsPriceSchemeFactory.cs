using System;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public sealed class BuyAndGetFreeItemsPriceSchemeFactory : IPricingSchemeFactory
    {
        public PriceScheme PriceScheme => PriceScheme.BuyGetFree;

        public IPriceScheme Create(StockPriceScheme stockPriceScheme)
        {
            if (stockPriceScheme.PriceSchemeDetail is BuyAndGetFreePriceSchemeDetail detail)
                return new BuyAndGetFreePriceScheme(detail);

            throw new ArgumentException("Invalid price scheme detail");
        }
    }
}
