using System;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Models
{
    public sealed class BundledStockPriceScheme : IPriceScheme
    {
        private readonly BundledPriceSchemeDetail _bundledPriceSchemeDetail;

        public BundledStockPriceScheme(BundledPriceSchemeDetail bundledPriceSchemeDetail)
        {
            _bundledPriceSchemeDetail = bundledPriceSchemeDetail;
        }
      
        public decimal ComputeCost(StockItem stockItem)
        {
            var quantity = stockItem.Quantity;

            var stock = stockItem.Stock;

            var bundledPrice = ComputeCostPerBundle(quantity);

            var perItemPrice = ComputeCostPerItem(quantity, stock.Price, _bundledPriceSchemeDetail.CountPerBundle);

            return bundledPrice + perItemPrice;
        }

        private decimal ComputeCostPerBundle(double quantity)
        {
            var countPerBundle = _bundledPriceSchemeDetail.CountPerBundle;

            if (quantity < countPerBundle)
                return 0;

            var bundledQuantity = Math.Floor(quantity / countPerBundle);

            return _bundledPriceSchemeDetail.Price * (decimal)bundledQuantity;
        }

        private static decimal ComputeCostPerItem(double quantity, decimal price, int countPerBundle)
        {
            var perPieceQuantity = quantity % countPerBundle;

            return price * (decimal)perPieceQuantity;
        }
    }
}
