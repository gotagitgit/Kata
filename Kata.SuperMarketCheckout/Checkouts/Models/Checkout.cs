using System;
using System.Collections.Immutable;
using System.Linq;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Checkouts.Models
{
    public sealed class Checkout
    {
        private Checkout() : this(ImmutableList<StockItem>.Empty)
        {
        }

        public Checkout(ImmutableList<StockItem> stockItems)
        {
            StockItems = stockItems;
        }

        public static Checkout Empty => new();

        public ImmutableList<StockItem> StockItems { get; }

        public decimal Total => Math.Round(StockItems.Sum(x => x.ItemPrice), 2);

        public Checkout AddItem(StockItem item)
        {
            if (TryUpdateExistingStockItems(item, out var checkout))
                return checkout;

            var updatedStockItems = StockItems.Add(item);

            return new Checkout(updatedStockItems);
        }

        private bool TryUpdateExistingStockItems(StockItem item, out Checkout checkout)
        {
            checkout = Checkout.Empty;

            var builder = StockItems.ToBuilder();

            var stockItem = builder.Find(x => x.Stock.Id == item.Stock.Id);

            if (stockItem == null)
                return false;

            var quantity = item.Quantity + stockItem.Quantity;

            var updatedStockItem = stockItem.WithQuantity(quantity);

            var stockItems = StockItems.Replace(stockItem, updatedStockItem);

            checkout = new Checkout(stockItems);

            return true;
        }
    }
}
