using System;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Models
{
    public sealed class BuyAndGetFreePriceScheme : IPriceScheme
    {
        private readonly BuyAndGetFreePriceSchemeDetail _buyAndGetFreePriceSchemeDetail;

        public BuyAndGetFreePriceScheme(BuyAndGetFreePriceSchemeDetail buyAndGetFreePriceSchemeDetail)
        {
            _buyAndGetFreePriceSchemeDetail = buyAndGetFreePriceSchemeDetail;
        }

        public decimal ComputeCost(StockItem stockItem)
        {
            var quantity = stockItem.Quantity;

            var pricedItemCount = _buyAndGetFreePriceSchemeDetail.PricedItemCount;

            var freeItemCount = _buyAndGetFreePriceSchemeDetail.FreeItemCount;

            if (quantity < pricedItemCount)
                throw new ArgumentException("Items have insufficient count for the price scheme to apply");

            var bundledQuantity = Math.Ceiling(quantity / (pricedItemCount + freeItemCount));

            var pricedQuantity = bundledQuantity * pricedItemCount;

            return stockItem.Stock.Price * (decimal)pricedQuantity;
        }
    }
}
