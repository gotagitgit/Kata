using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Api.Dtos.Checkouts
{
    public class CheckoutItemDto
    {
        public Guid Sku { get; set; }
        public double Quantity { get; set; }
        public UnitOfMeasure Uom { get; set; }
    }
}
