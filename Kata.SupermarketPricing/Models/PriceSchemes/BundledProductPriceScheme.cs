using System;

namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public sealed class BundledProductPriceScheme : IPriceScheme
    {
        private const int ItemCount = 3;

        private double _price = 2;

        public double ComputeItemPrice(Product product, double quantity)
        {

            var bundledPrice = ComputeCostPerBundle(quantity);

            var perItemPrice  = ComputeCostPerItem(quantity, product.Price);

            return bundledPrice + perItemPrice;
        }

        private double ComputeCostPerBundle(double quantity)
        {
            if (quantity < ItemCount)
                return 0;

            var bundledQuantity = Math.Floor(quantity / ItemCount);

            return _price * bundledQuantity;
        }

        private static double ComputeCostPerItem(double quantity, double price)
        {
            var perPieceQuantity = quantity % ItemCount;

            return price * perPieceQuantity;
        }

        public double ComputeItemPriceWithUOM(Product product, double quantity, double uomConversion)
        {
            throw new NotImplementedException();
        }
    }
}
