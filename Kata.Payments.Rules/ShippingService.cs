using System.Linq;
using Kata.Payments.Rules.Models;

namespace Kata.Payments.Rules
{
    public interface IShippingService
    {
        void ProcessShipping(Order order);
    }

    public sealed class ShippingService : IShippingService
    {
        private readonly IStockService _stockService;

        public ShippingService(IStockService stockService)
        {
            _stockService = stockService;
        }

        public void ProcessShipping(Order order)
        {
            var products = order.OrderItems.Select(x => x.Product).ToList();

            var ordersAreInStock = products.All(x => _stockService.IsProductInStock(x.Id));

            if (ordersAreInStock)
                order.WithOrderStatus(OrderStatus.Completed);
        }
    }
}
