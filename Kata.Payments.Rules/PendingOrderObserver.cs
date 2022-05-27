using Kata.Payments.Rules.Models;

namespace Kata.Payments.Rules
{
    public class PendingOrderObserver : OrderObserverBase
    {  
        protected override void UpdateOrder(Order order)
        {
            if (order.OrderStatus != OrderStatus.Pending)
                return;
        }
    }
}
