using Kata.SuperMarketCheckout.Api.Dtos.Checkouts;
using Kata.SuperMarketCheckout.Checkouts.Models;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Api.Mappers.Checkouts
{
    public class CheckoutMapper : ICheckoutMapper
    {
        public CheckoutItem ToModel(CheckoutItemDto dto)
        {
            return new CheckoutItem(
                dto.Sku,
                dto.Quantity,
                dto.Uom);
        }

        public CheckoutDto ToDto(Checkout checkout)
        {
            var stockItems = checkout.StockItems.Select(x => ToDto(x.Stock)).ToList();

            return new CheckoutDto
            {
                Stocks = stockItems,
                Total = checkout.Total,
            };
        }

        private static StockItemDto ToDto(Stock stock)
        {
            return new StockItemDto
            {
                Id = stock.Id,
                Name = stock.Name,
                Price = stock.Price,
                Uom = stock.Uom,
            };
        }
    }
}
