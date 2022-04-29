using System;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Checkouts.Models
{
    public sealed class CheckoutItem
    {
        public CheckoutItem(Guid sku, double quantity, UnitOfMeasure uom)
        {
            Sku = sku;
            Quantity = quantity;
            Uom = uom;
        }

        public Guid Sku { get; }
        public double Quantity { get; }
        public UnitOfMeasure Uom { get; }
    }
}
