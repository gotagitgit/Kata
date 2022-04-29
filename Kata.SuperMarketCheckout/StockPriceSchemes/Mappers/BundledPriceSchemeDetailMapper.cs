using System.Xml.Linq;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Mappers
{
    public sealed class BundledPriceSchemeDetailMapper : IPriceSchemeDetailMapper
    {
        public PriceScheme PriceScheme => PriceScheme.Bundled;

        public IPriceSchemeDetail ToDetail(string xml)
        {
            var detail = string.IsNullOrWhiteSpace(xml) ? null : XElement.Parse(xml);

            var countPerBundleValue = detail.Element("CountPerBundle").Value;

            var priceValue = detail.Element("Price").Value;

            _ = int.TryParse(countPerBundleValue, out var countePerBundle);

            _ = decimal.TryParse(priceValue, out var price);

            return new BundledPriceSchemeDetail(countePerBundle, price);
        }
    }
}
