using System;
using Kata.SupermarketPricing.Models.UOMs;

namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public sealed class ConvertedPriceScheme : IPriceScheme
    {
        public double ComputeItemPrice(Product product, ItemMeasure itemMeasure)
        {
            return itemMeasure.Quantity * ConvertToPound(itemMeasure.Uom) * product.Price;
        }

        private double ConvertToPound(UnitOfMeasure uom)
        {
            var conversionFactor = uom switch
            {
                UnitOfMeasure.Kg => 2.20462,
                UnitOfMeasure.lb => 1,
                UnitOfMeasure.oz => 0.0625,
                _ => throw new ArgumentException($"Can't convert price to {uom}"),
            };

            return conversionFactor;
        }
    }
}
