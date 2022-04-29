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
            var stockItems = checkout.StockItems.Select(ToDto).ToList();

            return new CheckoutDto
            {
                Stocks = stockItems,
                Total = checkout.Total,
            };
        }

        private static StockItemDto ToDto(StockItem stockItem)
        {
            var stock = stockItem.Stock;

            return new StockItemDto
            {
                Id = stock.Id,
                Name = stock.Name,
                Price = stock.Price,
                Quantity = stockItem.Quantity,
                Uom = stock.Uom,
            };
        }
    }
}
