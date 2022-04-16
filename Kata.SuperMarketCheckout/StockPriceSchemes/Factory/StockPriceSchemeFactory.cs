using System.Collections.Generic;
using System.Linq;
using Kata.SuperMarket.Data.StockPriceSchemes;
using Kata.SuperMarketCheckout.StockPriceSchemes.Mappers;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public sealed class StockPriceSchemeFactory : IStockPriceSchemeFactory
    {
        private readonly IDictionary<PriceScheme, IPriceSchemeDetailMapper> _priceSchemeDetailMappers;

        public StockPriceSchemeFactory(IEnumerable<IPriceSchemeDetailMapper> priceSchemeDetailMappers)
        {
            _priceSchemeDetailMappers = priceSchemeDetailMappers.ToDictionary(x => x.PriceScheme, x => x);
        }

        public StockPriceScheme ToModel(StockPriceSchemeDto dto)
        {
            var detail = CreateDetail(dto);

            return new StockPriceScheme(
                dto.Id,
                dto.StockId,
                (PriceScheme)dto.PriceScheme,
                dto.IsActive,
                detail);
        }

        private IPriceSchemeDetail CreateDetail(StockPriceSchemeDto dto)
        {
            var priceScheme = (PriceScheme)dto.PriceScheme;

            var detailMapper = _priceSchemeDetailMappers[priceScheme];

            return detailMapper.ToDetail(dto.PriceSchemeDetail);
        }
    }
}
