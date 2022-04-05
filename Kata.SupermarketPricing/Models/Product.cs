using System;
using Kata.SupermarketPricing.Models.PriceSchemes;
using Kata.SupermarketPricing.Models.UOMs;

namespace Kata.SupermarketPricing.Models
{
    public sealed class Product
    {
        public Product(
            Guid id,
            string name,
            double price,
            UnitOfMeasure uom,
            IPriceScheme priceScheme)
        {
            Id = id;
            Name = name;
            Price = price;
            Uom = uom;
            PriceScheme = priceScheme;
        }

        public Guid Id { get; }

        public string Name { get; }

        public double Price { get; }
        public UnitOfMeasure Uom { get; }
        public IPriceScheme PriceScheme { get; }
    }
}
