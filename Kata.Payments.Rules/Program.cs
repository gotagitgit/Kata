using System;
using System.Collections.Generic;
using Kata.Payments.Rules.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kata.Payments.Rules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            Configure(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var orderPaymentProvider = serviceProvider.GetService<OrderPaymentProvider>();

            SubscribeToOrderProvider(serviceProvider, orderPaymentProvider);

            var order = CreateOrder();

            orderPaymentProvider.HandleOrder(order);

            orderPaymentProvider.End();

            Console.ReadLine();
        }

        private static void SubscribeToOrderProvider(ServiceProvider serviceProvider, OrderPaymentProvider orderPaymentProvider)
        {
            var newOrderObserver = serviceProvider.GetService<NewOrderObserver>();            

            var pendingOrderObserver = serviceProvider.GetService<PendingOrderObserver>();

            newOrderObserver.Subscribe(orderPaymentProvider);

            pendingOrderObserver.Subscribe(orderPaymentProvider);
        }

        private static Order CreateOrder()
        {
            var product = new Product(Guid.NewGuid(), "Product 1");

            var orderItems = new List<OrderItem>
            {
                new OrderItem(product, 2)
            };

            return new Order(Guid.NewGuid(), PaymentType.CreditCard, OrderStatus.New, 23m, orderItems);
        }

        private static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IShippingService, ShippingService>();
            serviceCollection.AddScoped<IStockService, StockService>();
            serviceCollection.AddScoped<OrderPaymentProvider>();            
            serviceCollection.AddScoped<NewOrderObserver>();
            serviceCollection.AddScoped<PendingOrderObserver>();
        }
    }
}
