namespace Kata.SuperMarketCheckout.Api.Dtos.Checkouts
{
    public class CheckoutDto
    {
        public IList<StockItemDto> Stocks { get; set; }
        public decimal Total { get; set; }
    }
}
