using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kata.SuperMarketCheckout.Checkouts.Models;
using Kata.SuperMarketCheckout.Stocks.Models;
using Kata.SuperMarketCheckout.Stocks.Repository;

namespace Kata.SuperMarketCheckout.Checkouts.Service
{
    public sealed class CheckoutService : ICheckoutService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IDictionary<Guid, Stock> _stockCache;

        public CheckoutService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _stockCache = new Dictionary<Guid, Stock>();
        }

        public async ValueTask<Checkout> CheckoutItemsAsync(IList<CheckoutItem> checkoutItems)
        {
            var checkout = Checkout.Empty;

            foreach (var checkoutItem in checkoutItems)
            {
                var stock = await GetStockAsync(checkoutItem.Sku);

                var stockItem = new StockItem(stock, checkoutItem.Quantity);

                checkout = checkout.AddItem(stockItem);
            }

            return checkout;
        }

        private async ValueTask<Stock> GetStockAsync(Guid id)
        {
            if (_stockCache.TryGetValue(id, out var existingStock))
                return existingStock;

            var stock = await _stockRepository.FindAsync(id);

            _stockCache.Add(stock.Id, stock);

            return stock;
        }
    }
}
