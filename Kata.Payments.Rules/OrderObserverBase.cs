using System;
using Kata.Payments.Rules.Models;

namespace Kata.Payments.Rules
{
    public abstract class OrderObserverBase : IObserver<Order>
    {
        private IDisposable _unsubscriber;

        public virtual void Subscribe(IObservable<Order> provider)
        {
            if (provider != null)
            {
                _unsubscriber = provider.Subscribe(this);
            }
        }

        public void OnCompleted()
        {
            _unsubscriber.Dispose();
        }

        public void OnError(Exception error)
        {
            // Do nothing
        }

        public void OnNext(Order order)
        {
            UpdateOrder(order);
        }

        protected abstract void UpdateOrder(Order order);
    }
}
