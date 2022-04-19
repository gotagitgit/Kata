using System.Xml.Linq;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Mappers
{
    public sealed class BuyAndGetFreePriceSchemeDetailMapper : IPriceSchemeDetailMapper
    {
        public PriceScheme PriceScheme => PriceScheme.BuyGetFree;

        public IPriceSchemeDetail ToDetail(string xml)
        {
            var detail = string.IsNullOrWhiteSpace(xml) ? null : XElement.Parse(xml);

            var pricedItemCountValue = detail.Element("PricedItemCount").Value;

            var freeItemCountValue = detail.Element("FreeItemCount").Value;

            _ = int.TryParse(pricedItemCountValue, out var pricedItemCount);

            _ = int.TryParse(freeItemCountValue, out var freeItemCount);

            return new BuyAndGetFreePriceSchemeDetail(pricedItemCount, freeItemCount);
        }
    }
}
