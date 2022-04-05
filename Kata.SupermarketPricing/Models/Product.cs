using System;
using Kata.SupermarketPricing.Models.PriceSchemes;

namespace Kata.SupermarketPricing.Models
{
    public sealed class Product
    {
        public Product(
            Guid id,
            string name,
            double price,
            string uom,
            IPriceScheme priceScheme)
        {
            Id = id;
            Name = name;
            Price = price;
            UnitOfMeasure = uom;
            PriceScheme = priceScheme;
        }

        public Guid Id { get; }

        public string Name { get; }

        public double Price { get; }

        public string UnitOfMeasure { get; }

        public IPriceScheme PriceScheme { get; }
    }
}
