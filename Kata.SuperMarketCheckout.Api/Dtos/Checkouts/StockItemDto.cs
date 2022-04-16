using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Api.Dtos.Checkouts
{
    public class StockItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public UnitOfMeasure Uom { get; set; }
    }
}
