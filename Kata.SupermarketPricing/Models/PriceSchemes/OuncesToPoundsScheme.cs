using System;

namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public sealed class OuncesToPoundsScheme : IPriceScheme
    {
        private double _price = 1.99;

        public double ComputeItemPriceWithUOM(Product product, double quantity, double uomConversion)
        {
            var price = ComputeCostWithConversion(uomConversion);

            return Math.Round(price * quantity, 2);
        }

        private double ComputeCostWithConversion(double uomConversion)
        {
            return _price * uomConversion;
        }

        public double ComputeItemPrice(Product product, double quantity)
        {
            throw new NotImplementedException();
        }
    }
}