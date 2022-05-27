using System;

namespace Kata.Payments.Rules
{
    public interface IStockService
    {
        bool IsProductInStock(Guid id);
    }

    public sealed class StockService : IStockService
    {
        public bool IsProductInStock(Guid id)
        {
            return true;
        }
    }
}
