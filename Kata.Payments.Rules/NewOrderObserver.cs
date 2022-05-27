using Kata.Payments.Rules.Models;

namespace Kata.Payments.Rules
{ 
    public class NewOrderObserver : OrderObserverBase
    {
        private readonly IShippingService _shippingService;

        public NewOrderObserver(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        protected override void UpdateOrder(Order order)
        {
            if (order.OrderStatus != OrderStatus.New)
                return;

            if (order.PaymentType == PaymentType.CreditCard)
                _shippingService.ProcessShipping(order);
            else
                _ = order.WithOrderStatus(OrderStatus.Pending);
        }
    }
}
