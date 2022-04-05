﻿namespace Kata.SupermarketPricing.Models.PriceSchemes
{
    public interface IPriceScheme
    {
        double ComputeItemPrice(Product product, double quantity);
        double ComputeItemPriceWithUOM(Product product, double quantity, double uomConversion);
    }
}