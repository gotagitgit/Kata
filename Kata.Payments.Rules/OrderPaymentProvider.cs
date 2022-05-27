using System;
using System.Collections.Generic;
using Kata.Payments.Rules.Models;

namespace Kata.Payments.Rules
{
    public sealed class OrderPaymentProvider : IObservable<Order>
    {
        private readonly List<IObserver<Order>> _observers;

        public OrderPaymentProvider()
        {
            _observers = new List<IObserver<Order>>();
        }

        public IDisposable Subscribe(IObserver<Order> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);

            return new OrderObserverUnsubscribe(_observers, observer);
        }

        public void HandleOrder(Order order)
        {
            foreach (var observer in _observers)
            {
                if (order == null)
                {
                    observer.OnError(new ArgumentNullException());
                }

                observer.OnNext(order);
            }
        }
        public void End()
        {
            foreach (var observer in _observers.ToArray())
            {
                observer.OnCompleted();
            }
            
            _observers.Clear();
        }

        private class OrderObserverUnsubscribe : IDisposable
        {
            private readonly IList<IObserver<Order>> _observers;
            private readonly IObserver<Order> _observer;

            public OrderObserverUnsubscribe(IList<IObserver<Order>> observers, IObserver<Order> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            private bool _disposed = false;

            public void Dispose()
            {
                if (_disposed)
                    return;

                Dispose(true);
            }

            private void Dispose(bool disposing)
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);

                _disposed = true;
            }
        }
    }

    
}
