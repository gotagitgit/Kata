using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;
using Kata.SuperMarketCheckout.StockPriceSchemes.Repository.cs;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Factory
{
    public sealed class PriceSchemeFactory : IPriceSchemeFactory
    {
        private readonly IStockPriceSchemeRepository _stockPriceSchemeRepository;
        private readonly IDictionary<PriceScheme, IPricingSchemeFactory> _priceSchemeFactories;

        public PriceSchemeFactory(
            IEnumerable<IPricingSchemeFactory> pricingSchemeFactories,
            IStockPriceSchemeRepository stockPriceSchemeRepository)
        {
            _stockPriceSchemeRepository = stockPriceSchemeRepository;
            _priceSchemeFactories = pricingSchemeFactories.ToDictionary(x => x.PriceScheme, x => x);
        }

        public async ValueTask<IPriceScheme> CreateAsync(Guid id)
        {
            var stockPriceScheme = await _stockPriceSchemeRepository.FindByStockIdAsync(id);

            if (_priceSchemeFactories.TryGetValue(stockPriceScheme.PriceScheme, out var factory))
                return factory.Create(stockPriceScheme);

            throw new ArgumentException("Price scheme does not exists");
        }
    }
}
