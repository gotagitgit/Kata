using System;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Models
{
    public sealed class StockPriceScheme
    {
        public StockPriceScheme(
            Guid id,
            Guid stockId,
            PriceScheme priceScheme,
            bool isActive,
            IPriceSchemeDetail priceSchemeDetail)
        {
            Id = id;
            StockId = stockId;
            PriceScheme = priceScheme;
            IsActive = isActive;
            PriceSchemeDetail = priceSchemeDetail;
        }

        public Guid Id { get; }
        public Guid StockId { get; }
        public PriceScheme PriceScheme { get; }
        public bool IsActive { get; }
        public IPriceSchemeDetail PriceSchemeDetail { get; }
    }
}
