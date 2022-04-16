namespace Kata.SuperMarketCheckout.StockPriceSchemes.Models
{
    public sealed class BundledPriceSchemeDetail : IPriceSchemeDetail
    {
        public BundledPriceSchemeDetail(int countPerBundle, decimal price)
        {
            CountPerBundle = countPerBundle;
            Price = price;
        }

        public int CountPerBundle { get; }
        public decimal Price { get; }
    }
}
