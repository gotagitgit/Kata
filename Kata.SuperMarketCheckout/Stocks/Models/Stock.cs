using System;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.Stocks.Models
{
    public sealed class Stock
    {
        public Stock(Guid id, string name, decimal price, UnitOfMeasure uom, IPriceScheme priceScheme)
        {
            Id = id;
            Name = name;
            Price = price;
            Uom = uom;
            PriceScheme = priceScheme;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public UnitOfMeasure Uom { get; }
        public IPriceScheme PriceScheme { get; }
    }
}
