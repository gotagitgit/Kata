using System;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public sealed class BundledPriceSchemeFactory : IPricingSchemeFactory
    {
        public PriceScheme PriceScheme => PriceScheme.Bundled;

        public IPriceScheme Create(StockPriceScheme stockPriceScheme)
        {
            if (stockPriceScheme.PriceSchemeDetail is BundledPriceSchemeDetail detail)
                return new BundledStockPriceScheme(detail);

            throw new ArgumentException("Invalid price scheme detail");
        }
    }
}
