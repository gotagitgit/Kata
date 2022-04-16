using System.Threading.Tasks;
using Kata.SuperMarket.Data.Stocks;
using Kata.SuperMarketCheckout.StockPriceSchemes.Factory;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Stocks.Factory
{
    public sealed class StockFactory : IStockFactory
    {
        private readonly IPriceSchemeFactory _priceSchemeFactory;

        public StockFactory(IPriceSchemeFactory priceSchemeFactory)
        {
            _priceSchemeFactory = priceSchemeFactory;
        }

        public async ValueTask<Stock> ToModelAsync(StockDto dto)
        {
            var priceScheme = await _priceSchemeFactory.CreateAsync(dto.Id);

            return new Stock(
                dto.Id,
                dto.Name,
                dto.Price,
                (UnitOfMeasure)dto.Uom,
                priceScheme);
        }
    }
}
