using System;

namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public sealed class BuyAndGetFreeItemsPriceScheme : IPriceScheme
    {
        private const int PricedItemCount = 2;

        private const int FreeItemCount = 1;

        public double ComputeItemPrice(Product product, ItemMeasure itemMeasure)
        {
            var quantity = itemMeasure.Quantity;

            if (quantity < PricedItemCount)
                throw new ArgumentException("Items have insufficient count for the price scheme to apply");

            var bundledQuantity = Math.Ceiling(quantity / (PricedItemCount + FreeItemCount));

            return product.Price * bundledQuantity;
        }
    }
}
