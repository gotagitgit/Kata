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
            IPriceScheme priceScheme)
        {
            Id = id;
            Name = name;
            Price = price;
            PriceScheme = priceScheme;
        }

        public Guid Id { get; }

        public string Name { get; }

        public double Price { get; }

        public IPriceScheme PriceScheme { get; }
    }
}
