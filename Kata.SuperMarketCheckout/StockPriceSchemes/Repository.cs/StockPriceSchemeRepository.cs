using System;
using System.Threading.Tasks;
using Kata.SuperMarket.Data.StockPriceSchemes;
using Kata.SuperMarketCheckout.StockPriceSchemes.Factory;
using Kata.SuperMarketCheckout.StockPriceSchemes.Models;

namespace Kata.SuperMarketCheckout.StockPriceSchemes.Repository.cs
{
    public sealed class StockPriceSchemeRepository : IStockPriceSchemeRepository
    {
        private readonly IStockPriceSchemeDao _stockPriceSchemeDao;
        private readonly IStockPriceSchemeFactory _stockPriceSchemeFactory;

        public StockPriceSchemeRepository(IStockPriceSchemeDao stockPriceSchemeDao, IStockPriceSchemeFactory stockPriceSchemeFactory)
        {
            _stockPriceSchemeDao = stockPriceSchemeDao;
            _stockPriceSchemeFactory = stockPriceSchemeFactory;
        }

        public async ValueTask<StockPriceScheme> FindByStockIdAsync(Guid id)
        {
            var dto = await _stockPriceSchemeDao.FindByStockIdAsync(id);

            return _stockPriceSchemeFactory.ToModel(dto);
        }
    }
}
 