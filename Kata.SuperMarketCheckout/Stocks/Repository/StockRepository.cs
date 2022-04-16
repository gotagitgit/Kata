using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kata.SuperMarket.Data.Stocks;
using Kata.SuperMarketCheckout.Stocks.Factory;
using Kata.SuperMarketCheckout.Stocks.Models;

namespace Kata.SuperMarketCheckout.Stocks.Repository
{
    public sealed class StockRepository : IStockRepository
    {
        private readonly IStockDao _stockDao;
        private readonly IStockFactory _stockFactory;

        public StockRepository(
            IStockDao stockDao,
            IStockFactory stockFactory)
        {
            _stockDao = stockDao;
            _stockFactory = stockFactory;
        }

        public async ValueTask<IList<Stock>> FindAllAsync()
        {
            var stocks = await _stockDao.FindAllAsync();

            var result = new List<Stock>();

            foreach (var stockDto in stocks)
            {
                var stock = await _stockFactory.ToModelAsync(stockDto);

                result.Add(stock);
            }

            return result;
        }

        public async ValueTask<Stock> FindAsync(Guid id)
        {
            var stock = await _stockDao.FindAsync(id);

            return await _stockFactory.ToModelAsync(stock);
        }
    }
}
