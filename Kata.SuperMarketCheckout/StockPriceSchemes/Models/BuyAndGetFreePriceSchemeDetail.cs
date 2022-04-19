namespace Kata.SuperMarketCheckout.StockPriceSchemes.Models
{
    public sealed class BuyAndGetFreePriceSchemeDetail : IPriceSchemeDetail
    {
        public BuyAndGetFreePriceSchemeDetail(int pricedItemCount, int freeItemCount)
        {
            PricedItemCount = pricedItemCount;
            FreeItemCount = freeItemCount;
        }

        public int PricedItemCount { get; }
        public int FreeItemCount { get; }
    }
}
